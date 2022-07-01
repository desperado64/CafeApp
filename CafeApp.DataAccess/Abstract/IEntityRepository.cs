using CafeApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CafeApp.DataAccess.Abstract
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        int ExecuteSqlCommand(String sqlStr);

        List<TEntity> SqlQueryToGetResults(string sqlStr);

        List<TEntity> SqlQueryToGetResults<T>(string sqlStr) where T : class;
        TEntity SqlQueryToGetResult<T>(string sqlStr) where T : class;
    }
}
