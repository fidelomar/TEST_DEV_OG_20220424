using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Entities.Data;

namespace Web.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IRepository<TbPersonasFisica> TbPersonasFisica { get; }        
        public void Save();
    }
}
