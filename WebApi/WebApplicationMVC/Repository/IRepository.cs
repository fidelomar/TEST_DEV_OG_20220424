using System.Collections;
using System.Threading.Tasks;

namespace WebApplicationMVC.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable> GetAllAsync(string url, string token);
        Task<T[]> GetReportAsync(string url, string token);
        Task<T> GetAsync (string url, int Id, string token);
        Task<bool> CreateAsync(string url, T itemCreate, string token);
        Task<bool> UpdateAsync(string url, T itemUpdate, string token);
        Task<bool> DeleteAsync(string url, int Id, string token);
    }
}