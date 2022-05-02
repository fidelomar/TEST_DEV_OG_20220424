using Newtonsoft.Json;
using System.Collections;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationMVC.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IHttpClientFactory _clientFactory;
       
        public Repository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<bool> CreateAsync(string url, T itemCreate)
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, url);

            if (itemCreate != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(itemCreate), Encoding.UTF8, "application/json");
            }
            else
            {
                return false;
            }

            var client = _clientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.SendAsync(request);

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Created)
                return true;
            else
                return false;
        }
        public async Task<bool> DeleteAsync(string url, int Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, url + Id);        
            var client = _clientFactory.CreateClient();

            HttpResponseMessage responseMessage = await client.SendAsync(request);

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent)
                return true;
            else
                return false;
        }
        public async Task<IEnumerable> GetAllAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, url);
            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable>(jsonString);
            }
            else
            {
                return null;
            }
        }
        public async Task<T> GetAsync(string url, int Id)
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, url + Id);
            var client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

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
        public async Task<bool> UpdateAsync(string url, T itemUpdate)
        {
            var request = new HttpRequestMessage(HttpMethod.Patch, url);

            if(itemUpdate != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(itemUpdate), Encoding.UTF8, "application/json");
            }
            else
            {
                return false;
            }

            var client = _clientFactory.CreateClient();
            HttpResponseMessage responseMessage = await client.SendAsync(request);

            if (responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent)
                return true;
            else
                return false;
        }
    }
}