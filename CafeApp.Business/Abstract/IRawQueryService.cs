using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Business.Abstract
{
    public interface IRawQueryService
    {
        List<T> SqlQueryToGetResults<T>(string sqlStr);
        T SqlQueryToGetResult<T>(string sqlStr);
        int ExecuteSqlCommand(string sqlStr);

        //Async

        Task<List<T>> SqlQueryToGetResultsAsync<T>(string sqlStr);
        Task<T> SqlQueryToGetResultAsync<T>(string sqlStr);
        Task<int> ExecuteSqlCommandAsync(string sqlStr);
    }
}
