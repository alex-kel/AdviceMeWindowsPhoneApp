using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace adviceMe.Model
{
    [DataContract]  
    class User
    {
        public User(String name, String email, String password)
        {
            this.name = name;
            this.email = email;
            this.password = password;
        }
        [DataMember]
        public String name;
        [DataMember]
        public String email;
        [DataMember]
        public String password;

        
    }
}
