﻿using System;
using System.Collections.Generic;
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
        public String name;
        [DataMember]
        public String email;
        [DataMember]
        public String password;


    }
}
