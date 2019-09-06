using System;
using System.Collections.Generic;
using System.Net.Http;
using TestWebAPI.Model;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Text;

namespace TestWebAPI.Data
{
    public class UserData
    {
        HttpClient client = new HttpClient();
        List<User> usersList = null;

        /* LINK FROM AWS EC2 INSTANCE */
        string url = "http://3.91.188.122/user";

        /* GET USER LIST */
        public async Task<List<User>> GetDataAsync()
        {
            try
            {
                var response = await client.GetAsync(url);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    usersList = JsonConvert.DeserializeObject<List<User>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Error {0}", ex.Message);
            }

            return usersList;
        }

        /* ADD NEW USER */
        public async Task<List<User>> PostDataAsync(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client1 = new HttpClient();

            try
            {
                HttpResponseMessage response = await client1.PostAsync(url, data);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    usersList = JsonConvert.DeserializeObject<List<User>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Error {0}", ex.Message);
            }

            return usersList;

        }

        /* EDIT USER INFO */
        public async Task<List<User>> PutDataAsync(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client1 = new HttpClient();

            try
            {
                HttpResponseMessage response = await client1.PutAsync(url, data);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    usersList = JsonConvert.DeserializeObject<List<User>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Error {0}", ex.Message);
            }

            return usersList;

        }

        /* DELETE USER */
        public async Task<List<User>> DeleteDataAsync(User user)
        {
            HttpClient client1 = new HttpClient();

            url += "/" + user.Id;

            try
            {
                HttpResponseMessage response = await client1.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    usersList = JsonConvert.DeserializeObject<List<User>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"Error {0}", ex.Message);
            }

            return usersList;

        }

        public UserData()
        {

        }
    }
}
