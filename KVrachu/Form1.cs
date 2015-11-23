using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KVrachu
{
    public partial class MainForm : Form
    {
        private DataLoader dataLoader_;
        private List<DocTypeId> doctorTypes_;
        private List<DocProfile> doctorProfiles_;
        private System.Net.CookieContainer cookie_ = new System.Net.CookieContainer();
        private Parameters params_ = new Parameters();
        System.Timers.Timer timer_ = new System.Timers.Timer();
        private const int PERIOD = 30 * 1000;

        public MainForm()
        {
            InitializeComponent();
            dataLoader_ = new DataLoader();
            cmbDocTypes.ValueMember = "Type";
            cmbDocsForType.ValueMember = "Name";
            lbRest.ValueMember = "DateTime";
            lbBusy.ValueMember = "DateTime";
            
            txtLogin.Text = params_.Login = "pvirk"; // todo from xml
            txtPass.Text = params_.Password = "xep624";
            txtHospId.Text = params_.HospitalId = "13003369";
            txtHostUnitId.Text = params_.HospitalUnitId = "92";

            btnRegister.Enabled = false;
            btnSelectDoctor.Enabled = false;
            btnSelectType.Enabled = false;
            btnCheckInfinit.Enabled = false;

            timer_.AutoReset = true;
            timer_.Interval = PERIOD;
            timer_.SynchronizingObject = this;
            timer_.Elapsed += timer_Elapsed;
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            params_.Login = txtLogin.Text;
            params_.Password = txtPass.Text;
            params_.HospitalId = txtHospId.Text;
            params_.HospitalUnitId = txtHostUnitId.Text;

            // Get all doc types
            var req = WebRequests.GetGetRequest(UriStrings.GetStartPage(), cookie_);
            doctorTypes_ = dataLoader_.GetDoctorsTypes(req);
            req.Abort();
            cmbDocTypes.DataSource = doctorTypes_;
            btnSelectType.Enabled = true;

            txtLogin.Enabled = false;
            txtPass.Enabled = false;
            txtHospId.Enabled = false;
            txtHostUnitId.Enabled = false;
        }

        private void cmbDocTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            var val = ((DocTypeId)cmbDocTypes.SelectedItem);
            txtId.Text = params_.ProfileId = val.ProfileId;
        }

        private void btnSelectType_Click(object sender, EventArgs e)
        {
            if (cmbDocTypes.SelectedItem == null)
                return;

            var val = ((DocTypeId)cmbDocTypes.SelectedItem);
            params_.ProfileId = val.ProfileId;

            var req0 = WebRequests.GetGetRequest(UriStrings.GetDoctorsByType(val.ProfileId), cookie_);
            var r0 = req0.GetResponse();
            using (var sr0 = new System.IO.StreamReader(r0.GetResponseStream(), Encoding.GetEncoding(DataLoader.ENCODING)))
            {
                //string res0 = sr0.ReadToEnd();
                sr0.Close();
                r0.Close();
                req0.Abort();
            }

            var req = WebRequests.GetGetRequest(UriStrings.GetListOfDoctorsForHospital(params_.HospitalId, params_.HospitalUnitId), cookie_);
            doctorProfiles_ = dataLoader_.GetDoctorsForType(req, params_.ProfileId);
            req.Abort();

            cmbDocsForType.SelectedItem = null;
            cmbDocsForType.DataSource = new List<DocProfile>();
            cmbDocsForType.DataSource = doctorProfiles_;

            lbBusy.DataSource = new List<TimeRecord>();
            lbRest.DataSource = new List<TimeRecord>();
            
            btnSelectDoctor.Enabled = doctorProfiles_.Count > 0;
            btnRegister.Enabled = false;
            btnCheckInfinit.Enabled = doctorProfiles_.Count > 0;
            txtDocId.Text = "";
            txtDocDesc.Text = "";
        }

        private void GetDocTimetable(ref List<TimeRecord> rest, ref List<TimeRecord> busy)
        {
            var req = WebRequests.GetGetRequest(UriStrings.GetTimetablForDoctor(params_.DoctorId, params_.ProfileId, params_.HospitalId, params_.HospitalUnitId), cookie_);
            List<TimeRecord> timeRecords = new List<TimeRecord>();
            string name;
            string spec;
            dataLoader_.GetDocTimetable(req, ref timeRecords, out name, out spec);
            req.Abort();
            foreach (var rec in timeRecords)
            {
                if (rec.Type == TimeRecord.RESTTIME)
                    rest.Add(rec);
                else if (rec.Type == TimeRecord.BUSYTIME)
                    busy.Add(rec);
            }
            //rest.Sort;
            //busy.Sort();
        }

        private void Login()
        {
            // Login
            var req = WebRequests.GetPostRequest(cookie_, UriStrings.GetStartPage(),
                string.Format(UriStrings.LoginFormatStr, params_.Login, params_.Password));
            try
            {
                var r = req.GetResponse();
                // using (var sr = new System.IO.StreamReader(r.GetResponseStream(), Encoding.GetEncoding(DataLoader.ENCODING)))
                // {
                //     string res = sr.ReadToEnd();
                //     sr.Close();
                //}
                r.Close();
                req.Abort();
            }
            catch (System.Net.WebException we)
            {
                //System.Windows.Forms.MessageBox.Show(string.Format("{0} {1}", we.Status, we.Response));
                rtbLog.Text += string.Format("{0} {1}\r\n", we.Status, we.Response);
            }
            catch (Exception e)
            {
                //System.Windows.Forms.MessageBox.Show(e.Message);
                rtbLog.Text += e.Message + Environment.NewLine;
            }
        }

        private void RegisterForTimeAndDoc(TimeRecord dateTime)
        {
            // Send request for rigister
            var req2 = WebRequests.GetPostRequest(cookie_, UriStrings.GetRecordPage(),
                string.Format(UriStrings.RecordFormatStr, dateTime.Id));
            try
            {
                var r2 = req2.GetResponse();
                using (var sr2 = new System.IO.StreamReader(r2.GetResponseStream(), Encoding.GetEncoding(DataLoader.ENCODING)))
                {
                    string res2 = sr2.ReadToEnd();
                    sr2.Close();
                    if (res2.Contains(WebRequests.SECOND_STAGE_SIGN))
                    {
                        var req3 = WebRequests.GetGetRequest(UriStrings.GetRecordPage(), cookie_);
                        var r3 = req3.GetResponse();
                        //using (var sr3 = new System.IO.StreamReader(r3.GetResponseStream(), Encoding.GetEncoding(DataLoader.ENCODING)))
                        //{
                        //    string res3 = sr3.ReadToEnd();
                        //    sr3.Close();
                        //}
                        req3.Abort();
                    }
                }
                r2.Close();
                req2.Abort();
            }
            catch (System.Net.WebException we)
            {
                //System.Windows.Forms.MessageBox.Show(string.Format("{0} {1}", we.Status, we.Response));
                rtbLog.Text += string.Format("{0} {1}\r\n", we.Status, we.Response);
            }
            catch (Exception e)
            {
                //System.Windows.Forms.MessageBox.Show(e.Message);
                rtbLog.Text += e.Message + Environment.NewLine;
            }
        }

        private void btnSelectDoctor_Click(object sender, EventArgs e)
        {
            if (cmbDocsForType.SelectedItem == null)
                return;

            var val = ((DocProfile)cmbDocsForType.SelectedItem);
            params_.DoctorId = val.DoctorId;

            List<TimeRecord> rest = new List<TimeRecord>();
            List<TimeRecord> busy = new List<TimeRecord>();
            GetDocTimetable(ref rest, ref busy);

            lbRest.DataSource = rest;
            lbBusy.DataSource = busy;

            btnRegister.Enabled = rest.Count > 0;
        }

        private void cmbDocsForType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocsForType.SelectedItem == null)
                return;

            var val = ((DocProfile)cmbDocsForType.SelectedItem);
            txtDocDesc.Text = val.Description;
            txtDocId.Text = params_.DoctorId = val.DoctorId;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (lbRest.SelectedItem == null)
                return;

            var dateTime = (TimeRecord)lbRest.SelectedItem;
            
            Login();
            RegisterForTimeAndDoc(dateTime);
        }

        //private bool stop_ = false;
        //private string ProcForAvailabilityCheck()
        //{
        //    string ret = DateTime.Now + "Start\r\n";
        //    stop_ = false;
        //    while (!stop_)
        //    {
        //        // Get list of rest times
        //        List<TimeRecord> rest = new List<TimeRecord>();
        //        List<TimeRecord> busy = new List<TimeRecord>();
        //        GetDocTimetable(ref rest, ref busy);

        //        // If rest times exist - register for best time
        //        if (rest.Count > 0)
        //        {
        //            int bestTime = (int)numBestTime.Value * 60;
        //            TimeRecord bestMatch = rest[0];
        //            int bestDiff = Math.Abs(bestMatch.TimeInMinutes - bestTime);
        //            foreach (var rec in rest)
        //            {
        //                int diff = Math.Abs(rec.TimeInMinutes - bestTime);
        //                if (diff < bestDiff)
        //                {
        //                    bestMatch = rec;
        //                    bestDiff = diff;
        //                }
        //            }

        //            Login();
        //            RegisterForTimeAndDoc(bestMatch);
        //            ret += string.Format("{0} Удалось, запись {1}\r\n", DateTime.Now, bestMatch.DateTime);
        //            stop_ = true;
        //        }
        //        else
        //        {
        //            System.Threading.Thread.Sleep(PERIOD);
        //        }
        //    }
        //    ret += DateTime.Now + "Stop\r\n";
        //    return ret;
        //}

        //BackgroundWorker bw;
        
        private void btnCheckInfinit_Click(object sender, EventArgs e)
        {
            if (cmbDocsForType.SelectedItem == null)
                return;

            if (btnCheckInfinit.Text == "Стоп"/* && bw != null*/)
            {
                //stop_ = true;
                timer_.Enabled = false;
                btnCheckInfinit.Text = "Пытаться записаться до удачи";
                btnRegister.Enabled = true;
                btnSelectDoctor.Enabled = true;
                btnSelectType.Enabled = true;
                btnInit.Enabled = true;
                rtbLog.Text += string.Format("{0} Принудительная остановка\r\n", DateTime.Now);
                return;
            }

            var val = ((DocProfile)cmbDocsForType.SelectedItem);
            params_.DoctorId = val.DoctorId;
            rtbLog.Text = "";

            btnRegister.Enabled = false;
            btnSelectDoctor.Enabled = false;
            btnSelectType.Enabled = false;
            btnInit.Enabled = false;

            btnCheckInfinit.Text = "Стоп";

            //bw = new BackgroundWorker();
            //bw.WorkerSupportsCancellation = true;
            //bw.DoWork += bw_DoWork;
            //bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            //bw.RunWorkerAsync();

            rtbLog.Text = "";
            timer_.Enabled = true;
        }

        private void timer_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            // Get list of rest times
            List<TimeRecord> rest = new List<TimeRecord>();
            List<TimeRecord> busy = new List<TimeRecord>();
            GetDocTimetable(ref rest, ref busy);

            // If rest times exist - register for best time
            rtbLog.Text += string.Format("{0} Проверка свободного\r\n", DateTime.Now);
            if (rest.Count > 0)
            {
                int bestTime = (int)numBestTime.Value * 60;
                TimeRecord bestMatch = rest[0];
                int bestDiff = Math.Abs(bestMatch.TimeInMinutes - bestTime);
                foreach (var rec in rest)
                {
                    int diff = Math.Abs(rec.TimeInMinutes - bestTime);
                    if (diff < bestDiff)
                    {
                        bestMatch = rec;
                        bestDiff = diff;
                    }
                }

                Login();
                RegisterForTimeAndDoc(bestMatch);
                rtbLog.Text += string.Format("{0} Удалось, запись {1}\r\n", DateTime.Now, bestMatch.DateTime);
                timer_.Enabled = false;

                btnCheckInfinit.Text = "Пытаться записаться до удачи";
                btnRegister.Enabled = true;
                btnSelectDoctor.Enabled = true;
                btnSelectType.Enabled = true;
                btnInit.Enabled = true;
                rtbLog.Text += string.Format("{0} Остановка\r\n", DateTime.Now);
            }
        }

        //void bw_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    e.Result = ProcForAvailabilityCheck();
        //}

        //void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    rtbLog.Text = e.Result.ToString();

        //    btnCheckInfinit.Text = "Пытаться записаться до удачи";
        //    btnRegister.Enabled = true;
        //    btnSelectDoctor.Enabled = true;
        //    btnSelectType.Enabled = true;
        //    btnInit.Enabled = true;
        //}
    }
}
