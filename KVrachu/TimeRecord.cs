using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KVrachu
{
    class TimeRecord
    {
        public TimeRecord(string id, string dateTime, string type)
        {
            Id = id;
            DateTime = dateTime;
            Type = type;
        }

        public string Id { get; set; }
        public string Type { get; set; }

        private string dateTime_;
        public int Day { get; set; }
        public string Month { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int TimeInMinutes
        {
            get
            {
                return Minute + Hour * 60;
            }
        }

        public string DateTime
        {
            get
            {
                return dateTime_;
            }
            set
            {
                dateTime_ = value;
                int i1 = dateTime_.IndexOf(" ");
                if (i1 == -1) return;
                int v = 0;
                int.TryParse(dateTime_.Substring(0, i1), out v);
                Day = v;

                int i2 = dateTime_.IndexOf(",", i1);
                if (i2 == -1) return;
                Month = dateTime_.Substring(i1 + 1, i2 - i1 - 1);

                int i3 = dateTime_.IndexOf(":", i2);
                if (i3 == -1) return;
                int.TryParse(dateTime_.Substring(i2 + 1, i3 - i2 - 1).TrimStart(null), out v);
                Hour = v;

                int.TryParse(dateTime_.Substring(i3 + 1), out v);
                Minute = v;
            }
        }

        public const string RESTTIME = "Время свободно";
        public const string BUSYTIME= "Занято";
    }
}
