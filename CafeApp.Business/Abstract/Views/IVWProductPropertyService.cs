using CafeApp.Entities.Concrete.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Business.Abstract.Views
{
    public interface IVWProductPropertyService
    {
        List<VWProductProperty> GetAll(Expression<Func<VWProductProperty, bool>> filter = null);
        VWProductProperty Get(int id);
        VWProductProperty Get(Expression<Func<VWProductProperty, bool>> filter);
        VWProductProperty GetLast();
        VWProductProperty GetFirst();
        VWProductProperty GetNext(int id);
        VWProductProperty GetPrev(int id);

        ///////////// Aync ///////

        Task<List<VWProductProperty>> GetAllAsync(Expression<Func<VWProductProperty, bool>> filter = null);
        Task<VWProductProperty> GetAsync(int id);
        Task<VWProductProperty> GetAsync(Expression<Func<VWProductProperty, bool>> filter);
        Task<VWProductProperty> GetLastAsync();
        Task<VWProductProperty> GetFirstAsync();
        Task<VWProductProperty> GetNextAsync(int id);
        Task<VWProductProperty> GetPrevAsync(int id);
    }
}
