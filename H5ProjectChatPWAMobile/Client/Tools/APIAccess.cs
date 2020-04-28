using H5ProjectChatPWAMobile.Client.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.IO;
using System.Globalization;

namespace H5ProjectChatPWAMobile.Client.Tools
{
    public class APIAccess
    {
        private string IP;
        private string URL;
        private WebClient client;

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


            try
            {
                HttpClient httpClient = new HttpClient();
                var content = JsonConvert.SerializeObject(new UserItem { Username = username, Password = password });
                StringContent SC = new StringContent(content.ToString(), Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync(URL + "User/Test", SC);
                string d = await response.Result.Content.ReadAsStringAsync();
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.ToString() + " " + ex.Message.ToString());
                return false;
            }
            /*
            System.Diagnostics.Debug.WriteLine("......BEGINNNING WEBCLIENT UPLOAD......");
            client = new WebClient();
            client.Headers["Content-Type"] = "application/json";
            
            try
            {
                string response = client.UploadString(URL + "User/Login", "POST", jsonData);
                SingleTon.GetUser().Token = JsonConvert.DeserializeObject<UserItem>(response).Token;
                return true;
            }
            catch (WebException ex)
            {
                
                throw new Exception(ex.Status.ToString());
                return false;
            }
            */

        }

        public async Task<bool> CreateAccount(string username, string password, string ip)
        {
            password = BCrypt.Net.BCrypt.HashPassword(password);
            IP = ip;
            URL = "http://" + ip + "/api/";
            string URLCreateMessage = URL + "User/create";
            string jsonData = JsonConvert.SerializeObject(new UserItem
            {
                Username = username,
                Password = password
            });

            client = new WebClient();
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

        public async Task<int> CheckLastID()
        {
            string URLCreateMessage = URL + "Chat/GetMessagesLastID";
            client = new WebClient();
            client.Headers["Content-Type"] = "application/json";
            client.Headers[HttpRequestHeader.Authorization] = "Bearer " + SingleTon.GetUser().Token;
            try
            {
                return Convert.ToInt32(client.DownloadString(URLCreateMessage));
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public async Task<List<ChatItem>> GetMessages(int fromID)
        {
            string URLCreateMessage = URL + "Chat/GetMessages";
            client = new WebClient();
            client.Headers["Content-Type"] = "application/json";
            client.Headers[HttpRequestHeader.Authorization] = "Bearer " + SingleTon.GetUser().Token;
            string jsonData = JsonConvert.SerializeObject(new ChatItem { id = fromID });
            try
            {
                List<ChatItem> Messages = new List<ChatItem>();
                Messages = JsonConvert.DeserializeObject<List<ChatItem>>(client.UploadString(URLCreateMessage, "POST", jsonData));
                return Messages;
            }
            catch (Exception ex)
            {
                return new List<ChatItem>();
            }
        }

        public async Task<bool> PostMessage(ChatItem message)
        {
            string URLCreateMessage = URL + "Chat/PostMessages";
            client = new WebClient();
            client.Headers["Content-Type"] = "application/json";
            client.Headers[HttpRequestHeader.Authorization] = "Bearer " + SingleTon.GetUser().Token;
            string JsonData = JsonConvert.SerializeObject(message);

            try
            {
                client.UploadString(URLCreateMessage, "POST", JsonData);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
