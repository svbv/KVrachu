using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KVrachu
{
    class DocProfile
    {
        public DocProfile(string profile_id, string doctor_id, string name, string desc)
        {
            ProfileId = profile_id;
            DoctorId = doctor_id;
            Name = name;
            Description = desc;
        }

        public string ProfileId
        {
            get;
            set;
        }

        public string DoctorId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }
}
