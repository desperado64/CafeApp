using CafeApp.Business.Abstract;
using CafeApp.DataAccess.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CafeApp.Business.Concrete
{
    public class RawQueryManager : IRawQueryService
    {
        private IRawQueryDal rawQueryDal;

        public RawQueryManager(IRawQueryDal rawQueryDal)
        {
            this.rawQueryDal = rawQueryDal;
        }

        public int ExecuteSqlCommand(string sqlStr)
        {
            return rawQueryDal.ExecuteSqlCommand(sqlStr);
        }

        public Task<int> ExecuteSqlCommandAsync(string sqlStr)
        {
            return Task.Run(() =>
            {
                return ExecuteSqlCommand(sqlStr);
            });
        }

        public T SqlQueryToGetResult<T>(string sqlStr)
        {
            return rawQueryDal.SqlQueryToGetResult<T>(sqlStr);
        }

        public Task<T> SqlQueryToGetResultAsync<T>(string sqlStr)
        {
            return Task.Run(() =>
            {
                return SqlQueryToGetResult<T>(sqlStr);
            });
        }

        public List<T> SqlQueryToGetResults<T>(string sqlStr)
        {
            return rawQueryDal.SqlQueryToGetResults<T>(sqlStr);
        }

        public Task<List<T>> SqlQueryToGetResultsAsync<T>(string sqlStr)
        {
            return Task.Run(() =>
            {
                return SqlQueryToGetResults<T>(sqlStr);
            });
        }
    }
}
