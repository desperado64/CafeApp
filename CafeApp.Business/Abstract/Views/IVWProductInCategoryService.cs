using CafeApp.Entities.Concrete.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Business.Abstract.Views
{
    public interface IVWProductInCategoryService
    {
        List<VWProductInCategory> GetAll(Expression<Func<VWProductInCategory, bool>> filter = null);
        VWProductInCategory Get(int id);
        VWProductInCategory Get(Expression<Func<VWProductInCategory, bool>> filter);
        VWProductInCategory GetLast();
        VWProductInCategory GetFirst();
        VWProductInCategory GetNext(int id);
        VWProductInCategory GetPrev(int id);

        ///////////// Aync ///////

        Task<List<VWProductInCategory>> GetAllAsync(Expression<Func<VWProductInCategory, bool>> filter = null);
        Task<VWProductInCategory> GetAsync(int id);
        Task<VWProductInCategory> GetAsync(Expression<Func<VWProductInCategory, bool>> filter);
        Task<VWProductInCategory> GetLastAsync();
        Task<VWProductInCategory> GetFirstAsync();
        Task<VWProductInCategory> GetNextAsync(int id);
        Task<VWProductInCategory> GetPrevAsync(int id);
    }
}
