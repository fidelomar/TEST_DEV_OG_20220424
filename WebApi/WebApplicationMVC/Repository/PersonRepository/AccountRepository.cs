﻿#region Utils
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplicationMVC.Models;
#endregion

namespace WebApplicationMVC.Repository
{
    public class AccountRepository : Repository<UserModel>, IAccountRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public AccountRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<UserModel> LoginAsync(string url, UserModel user)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            
            if(user != null)
            {
                request.Content = new StringContent(
                    JsonConvert
                    .SerializeObject(user), 
                    Encoding.UTF8, "application/json"
                    );
            }
            else
            {
                return new UserModel();
            }

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<UserModel>(jsonString);
            }
            else
            {
                return new UserModel();
            }
        }
        public async Task<bool> RegisterAsync(string url, UserModel user)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (user != null)
            {
                request.Content = new StringContent(
                    JsonConvert
                    .SerializeObject(user),
                    Encoding.UTF8, "application/json"
                    );
            }
            else
            {
                return false;
            }

            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}