using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KVrachu
{
    class DataLoader
    {
        public const string ENCODING = "utf-8";

        public List<DocTypeId> GetDoctorsTypes(System.Net.HttpWebRequest req)
        {
            var r = req.GetResponse();
            var sr = new System.IO.StreamReader(r.GetResponseStream(), Encoding.GetEncoding(ENCODING));
            string res = sr.ReadToEnd();
            sr.Close();
            r.Close();
            
            var ret = new List<DocTypeId>();
            int i1 = res.IndexOf("hospitals?profile_id=");
            while (i1 != -1)
            {
                int i2 = res.IndexOf("\">", i1);
                string profile_id = res.Substring(i1 + "hospitals?profile_id=".Length, i2 - i1 - "hospitals?profile_id=".Length);
                string type;
                if (res.Substring(i2 + 35, 5) == "<span")
                {
                    int i3 = res.IndexOf("\">", i2 + 35) + "\">".Length;
                    int i4 = res.IndexOf("</span>", i3);
                    type = res.Substring(i3, i4 - i3);
                }
                else
                {
                    int i3 = res.IndexOf("</a></li>", i2 + 2);
                    type = res.Substring(i2 + 2, i3 - i2 - 2);
                }
                ret.Add(new DocTypeId(type, profile_id));

                i1 = res.IndexOf("hospitals?profile_id=", i1 + 1);
            }

            return ret;
        }

        public string GetDocTimetable(System.Net.HttpWebRequest req, ref List<TimeRecord> timeRecords,
            out string docName, out string docSpec)
        {
            System.Net.WebResponse resp = req.GetResponse();
            var sr = new System.IO.StreamReader(resp.GetResponseStream(), Encoding.GetEncoding(ENCODING));
            string res = sr.ReadToEnd();
            sr.Close();
            resp.Close();
            
            int i00 = res.IndexOf("Врач");
            int i01 = res.IndexOf("<a href=\"/service/record/doctors\">", i00) + "<a href=\"/service/record/doctors\">".Length;
            int i02 = res.IndexOf("</a></li>", i01);
            docName = res.Substring(i01, i02 - i01);

            i00 = res.IndexOf("Специалист");
            i01 = res.IndexOf("<a href=\"/service/record/profiles\">", i00) + "<a href=\"/service/record/profiles\">".Length;
            i02 = res.IndexOf("</a></li>", i01);
            docSpec = res.Substring(i01, i02 - i01);

            int i1 = res.IndexOf("<td id=\"");
            while (i1 != -1)
            {
                int i10 = res.IndexOf("\"", i1 + "<td id=\"".Length);
                string id = res.Substring(i1 + "<td id=\"".Length, i10 - i1 - "<td id=\"".Length);

                int i2 = res.IndexOf("rel=\"", i1) + "rel=\"".Length;
                int i3 = res.IndexOf("\" rel2=", i2);
                string dateTime = res.Substring(i2, i3 - i2);

                int i4 = res.IndexOf("alt=\"", i3) + "alt=\"".Length;
                int i5 = res.IndexOf("\">", i4);
                string type = res.Substring(i4, i5 - i4);

                timeRecords.Add(new TimeRecord(id, dateTime, type));
                
                i1 = res.IndexOf("<td id=\"", i1 + 1);
            }
            
            return res;
        }

        public List<DocProfile> GetDoctorsForType(System.Net.HttpWebRequest req, string profile_id)
        {
            var r = req.GetResponse();
            var sr = new System.IO.StreamReader(r.GetResponseStream(), Encoding.GetEncoding(ENCODING));
            string res = sr.ReadToEnd();
            sr.Close();
            r.Close();

            var ret = new List<DocProfile>();
            int i1 = res.IndexOf("timetable?doctor_id=");
            while (i1 != -1)
            {
                int i10 = res.IndexOf("&", i1);
                string doctor_id =  res.Substring(i1 + "timetable?doctor_id=".Length, i10 - i1 - "timetable?doctor_id=".Length);

                int i2 = res.IndexOf("\">", i10);
                i2 = res.IndexOf("\">", i2 + 1) + "\">".Length;
                int i3 = res.IndexOf("</span>", i2);
                string name = res.Substring(i2, i3 - i2);
                name = System.Text.RegularExpressions.Regex.Replace(name, @"\s+", " ");
                
                int i4 = res.IndexOf("\">", i3) + "\">".Length;
                int i5 = res.IndexOf("</span>", i4);
                string desc = res.Substring(i4, i5 - i4);
                desc = System.Text.RegularExpressions.Regex.Replace(desc, @"\s+", " ");

                ret.Add(new DocProfile(profile_id, doctor_id, name, desc));

                i1 = res.IndexOf("timetable?doctor_id=", i1 + 1);
            }

            return ret;
        }
    }
}
