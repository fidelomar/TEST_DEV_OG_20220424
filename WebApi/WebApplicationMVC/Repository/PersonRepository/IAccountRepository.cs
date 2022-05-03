using System.Threading.Tasks;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Repository
{
    public interface IAccountRepository : IRepository<UserModel>
    {
        Task<UserModel> LoginAsync(string url, UserModel user);
        Task<bool> RegisterAsync(string url, UserModel user);
    }
}