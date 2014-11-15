using adviceMe.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

namespace adviceMe.Api
{
    class API
    {
        public static String URL = "http://advisemeapp.herokuapp.com/api";
        /*public static String URL = "http://192.168.1.37:3000/api";*/
        public static String requestURL(String path)
        {
            return URL + path;

        }
      /*  public async static void doRequest(){
            using (var client = new HttpClient())
            {
                User user = new User("login", "email", "password");
                var data = new Dictionary<String, String>();
                DataContractJsonSerializer serialer = new DataContractJsonSerializer(typeof(User));
                using (MemoryStream stream = new MemoryStream())
                {
                   serialer.WriteObject(stream, user);
                   stream.Position = 0;
                   StreamReader sr = new StreamReader(stream);
                   String param = sr.ReadToEnd();
                   data["user"] =  param;
                }
                HttpResponseMessage result = await client.PostAsync(requestURL("/users.json"), new FormUrlEncodedContent(data));
                string resultContent = result.Content.ReadAsStringAsync().Result;
            }
        }*/

        public async static Task<HttpResponseMessage> doPost(Object obj, string path, String param)
        {
            using (var client = new HttpClient())
            {
                StringContent theContent = new StringContent(param, System.Text.Encoding.UTF8, "application/json"); 
                return await client.PostAsync(requestURL(path),theContent);
            }
        }

        public async static Task<HttpResponseMessage> doGet(Object obj, string path, String param)
        {
            using (var client = new HttpClient())
            {
                StringContent theContent = new StringContent(param, System.Text.Encoding.UTF8, "application/json");
                return await client.GetAsync(requestURL(path));
            }
        }

        public static string serialize(Object obj, System.Type type)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(type);
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, obj);
                stream.Position = 0;
                string json = Encoding.UTF8.GetString(stream.ToArray(), 0, stream.ToArray().Length);
                /*StreamReader sr = new StreamReader(stream);*/
                return json ;
            }
        }

    }
}
