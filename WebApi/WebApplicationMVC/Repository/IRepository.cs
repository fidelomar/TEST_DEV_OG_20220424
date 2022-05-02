using System.Collections;
using System.Threading.Tasks;

namespace WebApplicationMVC.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable> GetAllAsync(string url);
        Task<T> GetAsync (string url, int Id);
        Task<bool> CreateAsync(string url, T itemCreate);
        Task<bool> UpdateAsync(string url, T itemUpdate);
        Task<bool> DeleteAsync(string url, int Id);
    }
}