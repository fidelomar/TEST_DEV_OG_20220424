using Web.Entities.Data;

namespace Web.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext _context;
        public IRepository<TbPersonasFisica> _TbPersonasFisica;
        public IRepository<TbPersonasFisica> TbPersonasFisica
        {
            get
            {
                return _TbPersonasFisica == null ?
                    _TbPersonasFisica = new Repository<TbPersonasFisica>(_context) :
                    _TbPersonasFisica;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
