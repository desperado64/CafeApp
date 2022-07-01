using Currency.Api.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Api.DataAccess.Abstract
{
    public interface ISecondEntityRepository<T, V>
       where T : class, IEntity, new()
       where V : class
    {
        V Post(string url, T request);

        List<V> PostV2(string url, T request);

        V Post(string username, string password, string url, T request);


    }
}
