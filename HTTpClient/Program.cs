using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Text;

namespace HttppClient
{
    class Program
    {
        public static void Main()
        {
            var body = new NameValueCollection()
            {
                   { "client_id", "client" },
                   {"client_secret", "secret" },
                   {"grant_type", "client_credentials" },
                   {"scope", "api1" }
             };

            using (WebClient webclient = new WebClient())
            {
                   string result = string.Empty;
                   byte[] response =
                   webclient.UploadValues("http://localhost:5000/connect/token", body);
                   result = Encoding.UTF8.GetString(response);
                   var json = JsonConvert.DeserializeObject<RootObject>(result);
                   var token = json.access_token;
            }

            List<KeyValuePair<string, string>> keyValues = new List<KeyValuePair<string, string>>()
            {
                    new KeyValuePair<string, string>("client_id", "client"),
                    new KeyValuePair<string, string>("client_secret", "secret"),
                    new KeyValuePair<string, string>("grant_type", "client_credentials"),
                    new KeyValuePair<string, string>("scope", "api1")
             };

            using (HttpClient client = new HttpClient())
            {
                    var url = "http://localhost:5000/connect/token";
                    HttpContent content = new FormUrlEncodedContent(keyValues);
                    var result = client.PostAsync(url, content).Result;
                    string resultContent = result.Content.ReadAsStringAsync().Result;
                    var statusCode = result.StatusCode;
                    var json = JsonConvert.DeserializeObject<RootObject>(resultContent);
                    var token = json.access_token;
            }
        }
    }
}
    public class RootObject
    {
        public String access_token { get; set; }
        public String expires_in { get; set; }
        public String token_type { get; set; }
    }
    

