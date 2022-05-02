using System.Net.Http;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Repository
{    
    public class ReportRepository : Repository<ReportModel>, IReportRepository 
    {
        private readonly IHttpClientFactory _clientFactory;
        public ReportRepository(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }
    }
}