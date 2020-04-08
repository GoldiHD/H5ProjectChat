using H5ProjectChatDesktop.Entities;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace H5ProjectChatDesktop.Tools
{
    class APIMessenger
    {
        private string IP;
        private string URL;

        public async Task<bool> Login(string username, string password, string ip)
        {
            //password = Hashing.HashPassword(password,"pass");

            URL = "http://" + ip + "/api/";
            IP = ip;
            string jsonData = JsonConvert.SerializeObject(new UserItem
            {
                Username = username,
                Password = password
            });

            WebClient client = new WebClient();
            client.Headers["Content-Type"] = "application/json";

            try
            {
                string response = client.UploadString(URL + "User/Login", "POST", jsonData);
                SingleTon.SetUser(JsonConvert.DeserializeObject<UserItem>(response));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CreateAccount(string username, string password, string ip)
        {
            IP = ip;
            URL = "http://" + ip + "/api/";
            string URLCreateMessage = URL + "User/create";
            string jsonData = JsonConvert.SerializeObject(new UserItem
            {
                Username = username,
                Password = password
            });

            WebClient client = new WebClient();
            client.Headers["Content-Type"] = "application/json";
            try
            {
                string response = client.UploadString(URLCreateMessage, "POST", jsonData);
                SingleTon.SetUser(JsonConvert.DeserializeObject<UserItem>(response));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
