using System.Net.Http;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Repository
{
    public class PersonRepository : Repository<PersonModel>, IPersonRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public PersonRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}