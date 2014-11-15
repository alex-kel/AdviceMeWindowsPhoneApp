using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace adviceMe.Model
{
    [DataContract]
    class UserInfo
    {
        public UserInfo()
        {

        }
        [DataMember]
        public String id;
        [DataMember]
        public String email;
        [DataMember]
        public String name;

        public static UserInfo desirialize(String json)
        {
            return JsonConvert.DeserializeObject<UserInfo>(json.Substring(8, json.Length - 2));
        }


    }
}
