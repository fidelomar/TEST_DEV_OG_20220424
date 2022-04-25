﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Web.Repository
{
    public interface IRepository<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);                
        IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity data);
        void Delete(int id);
        void Update(TEntity data);
        void Save();

        IEnumerable<TEntity> ExecuteQuery(string spQuery, object[] parameters);
        //TEntity ExecuteQuerySingle(string spQuery, object[] parameters);
        //int ExecuteCommand(string spQuery, object[] parameters);

    }
}