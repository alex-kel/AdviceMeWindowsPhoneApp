using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adviceMe.models
{
    class User
    {
        private String name;
        private String email;
        private String password;

        public User(String email, String password, String name)
        {
            this.email = email;
            this.password = password;
            this.name = name;
        }

        public String getName(){
            return name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getPassword()
        {
            return this.password;
        }

        public void setPassword(String password)
        {
            this.password = password;
        }

        public String getEmail()
        {
            return this.email;
        }

        public void setEmail(String email)
        {
            this.email = email;
        }
    }
}
