using System.Net.Http;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Repository
{
    public class UserRepository : Repository<UserModel>, IUserRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public UserRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}