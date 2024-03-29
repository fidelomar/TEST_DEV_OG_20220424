﻿#region Utils
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApplicationMVC.Models;
#endregion
namespace WebApplicationMVC.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IHttpClientFactory _clientFactory;       
        public Repository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        #region Create
        public async Task<bool> CreateAsync(string url, T itemCreate, string token = "")
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);

            if (itemCreate != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(itemCreate), Encoding.UTF8, "application/json");
            }
            else
            {
                return false;
            }

            var client = _clientFactory.CreateClient();
            
            if (token != null && token.Length != 0)            
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage responseMessage = await client.SendAsync(request);            

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Created)
                return true;
            else
                return false;
        }
        #endregion
        #region Delete
        public async Task<bool> DeleteAsync(string url, int Id, string token = "")
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, url + Id);        
            var client = _clientFactory.CreateClient();

            if (token != null && token.Length != 0)
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage responseMessage = await client.SendAsync(request);

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent)
                return true;
            else
                return false;
        }
        #endregion
        #region Get
        public async Task<T> GetAsync(string url, int Id, string token = "")
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url + Id);
            var client = _clientFactory.CreateClient();

            if (token != null && token.Length != 0)
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.SendAsync(request);

            if (token != null && token.Length != 0)
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            else
            {
                return null;
            }
        }
        #endregion
        #region Update
        public async Task<bool> UpdateAsync(string url, T itemUpdate, string token = "")
        {
            var request = new HttpRequestMessage(HttpMethod.Put, url);

            if (itemUpdate != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(itemUpdate), Encoding.UTF8, "application/json");
            }
            else
            {
                return false;
            }

            var client = _clientFactory.CreateClient();

            if (token != null && token.Length != 0)            
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage responseMessage = await client.SendAsync(request);

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent)
                return true;
            else
                return false;
        }
        #endregion
        #region GetAll
        public async Task<IEnumerable> GetAllAsync(string url, string token = "")
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _clientFactory.CreateClient();

            if (token != null && token.Length != 0)
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonString);
            }
            else
            {
                return null;
            }
        }
        #endregion
        #region GetReport
        public async Task<IEnumerable> GetReportAsync(string url, string token = "")
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _clientFactory.CreateClient();

            if (token != null && token.Length != 0)
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var responseData = new { data = Enumerable.Empty<ReportModel>() };
                var deserialize = JsonConvert.DeserializeAnonymousType(jsonString, responseData);
                IEnumerable<ReportModel> items = null;
                items = deserialize.data;

                return items;
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}