using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KVrachu
{
    class DocTypeId
    {
        public DocTypeId(string type, string profile_id)
        {
            Type = type;
            ProfileId = profile_id;
        }

        public string Type
        {
            get;
            set;
        }

        public string ProfileId
        {
            get;
            set;
        }
    }
}
