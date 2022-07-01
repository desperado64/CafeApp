using CafeApp.Entities.Concrete.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Business.Abstract.Views
{
    public interface IVWProductCountInCategoryService
    {
        List<VWProductCountInCategory> GetAll(Expression<Func<VWProductCountInCategory, bool>> filter = null);
        VWProductCountInCategory Get(int id);
        VWProductCountInCategory Get(Expression<Func<VWProductCountInCategory, bool>> filter);
        VWProductCountInCategory GetLast();
        VWProductCountInCategory GetFirst();
        VWProductCountInCategory GetNext(int id);
        VWProductCountInCategory GetPrev(int id);

        ///////////// Aync ///////

        Task<List<VWProductCountInCategory>> GetAllAsync(Expression<Func<VWProductCountInCategory, bool>> filter = null);
        Task<VWProductCountInCategory> GetAsync(int id);
        Task<VWProductCountInCategory> GetAsync(Expression<Func<VWProductCountInCategory, bool>> filter);
        Task<VWProductCountInCategory> GetLastAsync();
        Task<VWProductCountInCategory> GetFirstAsync();
        Task<VWProductCountInCategory> GetNextAsync(int id);
        Task<VWProductCountInCategory> GetPrevAsync(int id);
    }
}
