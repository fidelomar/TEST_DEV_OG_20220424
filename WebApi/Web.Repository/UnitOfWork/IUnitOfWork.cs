using Web.Entities.Data;

namespace Web.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepository<TbPersonasFisica> TbPersonasFisica { get; }        
        public void Save();
    }
}