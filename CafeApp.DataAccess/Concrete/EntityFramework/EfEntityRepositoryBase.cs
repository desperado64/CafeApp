using AutoMapper;
using LinqKit;
using CafeApp.DataAccess.Abstract;
using CafeApp.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace CafeApp.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ?
                    context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().AsExpandable().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public int ExecuteSqlCommand(string sqlStr)
        {
            using (TContext context = new TContext())
            {
                return context.Database.ExecuteSqlRaw(sqlStr);
            }
        }

        public List<TEntity> SqlQueryToGetResults<T>(string sqlStr) where T : class
        {
            using (TContext context = new TContext())
            {

                List<T> list = ExecSQL<T>(context, sqlStr).ToList();
                var configuration = new MapperConfiguration(cfg => cfg.CreateMap<T, TEntity>());
                Mapper mapper = new Mapper(configuration);
                List<TEntity> listDest = mapper.Map<List<T>, List<TEntity>>(list);
                return listDest;
            }
        }
        public List<TEntity> SqlQueryToGetResults(string sqlStr)
        {
            using (TContext context = new TContext())
            {

                return context.Set<TEntity>().FromSqlRaw(sqlStr).ToList();

            }
        }

        public TEntity SqlQueryToGetResult<T>(string sqlStr)  where T : class
        {
            using (TContext context = new TContext())
            {
                T t = ExecSQL<T>(context,sqlStr).FirstOrDefault();
                var config = new MapperConfiguration(cfg => cfg.CreateMap<T, TEntity>());
                var mapper = new Mapper(config);
                TEntity entity = mapper.Map<TEntity>(t);
                return entity;
            }
        }

        public List<T> ExecSQL<T>(TContext context,string query)
        {
            using (var command = context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                context.Database.OpenConnection();

                List<T> list = new List<T>();
                using (var result = command.ExecuteReader())
                {
                    T obj = default(T);
                    while (result.Read())
                    {
                        obj = Activator.CreateInstance<T>();
                        foreach (PropertyInfo prop in obj.GetType().GetProperties())
                        {
                            if (!object.Equals(result[prop.Name], DBNull.Value))
                            {
                                prop.SetValue(obj, result[prop.Name], null);
                            }
                        }
                        list.Add(obj);
                    }
                }
                context.Database.CloseConnection();
                return list;
            }
        }
    }
}
