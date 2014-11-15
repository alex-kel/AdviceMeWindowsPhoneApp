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
/*        public static String URL = "http://advisemeapp.herokuapp.com/api";*/
        public static String URL = "http://192.168.1.37:3000/api";
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

        public async static void doPost(Object obj, string path, String param, System.Type type, Object writeTo)
        {
            using (var client = new HttpClient())
            {
                StringContent theContent = new StringContent(param, System.Text.Encoding.UTF8, "application/json"); 
                HttpResponseMessage result = await client.PostAsync(requestURL(path),theContent);
                writeTo = result.Content.ReadAsStringAsync().Result;
                UserInfo user = UserInfo.desirialize(writeTo as string);
                int debug = 0;
            }
        }

        public async static void doGet(Object obj, string path, System.Type type, Object writeTo)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.GetAsync(requestURL(path));
                writeTo = result.Content.ReadAsStringAsync().Result;
                int debug = 0;
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

        public static T deserializeJSON<T>(string json)
        {
            var instance = typeof(T);
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer deserializer = new DataContractJsonSerializer(instance.GetType());
                return (T)deserializer.ReadObject(ms);
            }
        }

    }
}
