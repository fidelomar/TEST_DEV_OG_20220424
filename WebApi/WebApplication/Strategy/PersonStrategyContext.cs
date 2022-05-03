#region Utils
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Entities.Data;
using Web.Repository.UnitOfWork;
#endregion

namespace WebApplication.Strategy
{
    public class PersonStrategyContext
    {
        private IPersonStrategy _strategy;
        public IPersonStrategy personStrategy
        {
            set
            {
                _strategy = value;
            }
        }
        public PersonStrategyContext(IPersonStrategy strategy)
        {
            _strategy = strategy;
        }
        public Task AddPerson(TbPersonasFisica personasFisica, DatabaseContext _context)
        {
            return this._strategy.AddPerson(personasFisica, _context);
        }
        public Task UpdatePerson(TbPersonasFisica personasFisica, DatabaseContext _context)
        {
            return this._strategy.UpdatePerson(personasFisica, _context);
        }
        public Task DeletePerson(int Id, DatabaseContext _context)
        {
            return this._strategy.DeletePerson(Id, _context);
        }
        public Task<IEnumerable<TbPersonasFisica>> GetPersons(IUnitOfWork _unitOfWork)
        {
            return this._strategy.GetPersons(_unitOfWork);
        }
        public Task<TbPersonasFisica> GetPerson(IUnitOfWork _unitOfWork, int PersonId)
        {
            return this._strategy.GetPerson(_unitOfWork, PersonId);
        }
    }
}