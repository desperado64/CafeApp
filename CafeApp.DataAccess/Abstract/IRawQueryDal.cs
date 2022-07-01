using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp.DataAccess.Abstract
{
    public interface IRawQueryDal
    {
        int ExecuteSqlCommand(string sqlStr);
        List<T> SqlQueryToGetResults<T>(string sqlStr);
        T SqlQueryToGetResult<T>(string sqlStr);
    }
}
