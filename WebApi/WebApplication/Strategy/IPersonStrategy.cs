using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Entities.Data;
using Web.Repository.UnitOfWork;

namespace WebApplication.Strategy
{
    public interface IPersonStrategy
    {
        public Task AddPerson(TbPersonasFisica model, DatabaseContext _context);
        public Task UpdatePerson(TbPersonasFisica model, DatabaseContext _context);
        public Task DeletePerson(TbPersonasFisica model, DatabaseContext _context);
        public Task<IEnumerable<TbPersonasFisica>> GetPersons(IUnitOfWork _unitOfWork);
        public Task<TbPersonasFisica> GetPerson(IUnitOfWork _unitOfWork, int PersonId);
    }
}