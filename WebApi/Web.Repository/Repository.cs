#region Utils
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Web.Entities.Data;
#endregion
namespace Web.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DatabaseContext _context;
        private DbSet<TEntity> _dbSet;
        public Repository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public IEnumerable<TEntity> Get() => _dbSet.ToList();
        public TEntity Get(int id) => _dbSet.Find(id);
        public void Delete(int id)
        {
            var dataToDelete = _dbSet.Find(id);
            _dbSet.Remove(dataToDelete);
        }
        public void Add(TEntity data) => _dbSet.Add(data);
        public void Save() => _context.SaveChanges();
        public void Update(TEntity data)
        {
            _dbSet.Attach(data);
            _context.Entry(data).State = EntityState.Modified;

        }
        public IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
        public IEnumerable<TEntity> ExecuteQuery(string query, params object[] parameters)
        {
            return _context.Set<TEntity>().FromSqlRaw(query);
        }
    }
}
