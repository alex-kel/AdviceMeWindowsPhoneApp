﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adviceMe.api
{
    class CommonApi
    {
        public static String url = "";
        public static String getUrl(String path){
            return url + path;
        }
    }
}
