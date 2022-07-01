using CafeApp.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CafeApp.DataAccess.Concrete.EntityFramework
{
    public class EfRawOueryBase<TContext> : IRawQueryDal where TContext : DbContext, new()
    {
        public int ExecuteSqlCommand(string sqlStr)
        {
            using (TContext context = new TContext())
            {
                return context.Database.ExecuteSqlRaw(sqlStr);
            }
        }

        public List<T> SqlQueryToGetResults<T>(string sqlStr)
        {
            using (TContext context = new TContext())
            {

                List<T> list = ExecSQL<T>(context, sqlStr).ToList();
                return list;
            }
        }

        public T SqlQueryToGetResult<T>(string sqlStr)
        {
            using (TContext context = new TContext())
            {
                T t = ExecSQL<T>(context, sqlStr).FirstOrDefault();
                return t;
            }
        }

        public List<T> ExecSQL<T>(TContext context, string query)
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
