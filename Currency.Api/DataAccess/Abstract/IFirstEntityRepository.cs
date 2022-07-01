using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Api.DataAccess.Abstract
{
    public interface IFirstEntityRepository<V> where V : class
    {
        List<V> GetList(string url);
        V Get(string url);

        V Get(string username, string password, string url);
    }
}
