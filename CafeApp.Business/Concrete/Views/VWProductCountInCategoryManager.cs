using CafeApp.Business.Abstract.Views;
using CafeApp.DataAccess.Abstract.Views;
using CafeApp.Entities.Concrete.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Business.Concrete.Views
{
    public class VWProductCountInCategoryManager : IVWProductCountInCategoryService
    {
        private IVWProductCountInCategoryDal productCountInCategoryDal;

        public VWProductCountInCategoryManager(IVWProductCountInCategoryDal productCountInCategoryDal)
        {
            this.productCountInCategoryDal = productCountInCategoryDal;
        }

        public VWProductCountInCategory Get(int id)
        {
            return productCountInCategoryDal.Get(x => x.CategoryID == id);
        }

        public async Task<VWProductCountInCategory> GetAsync(int id)
        {
            return await Task.Run(() =>
            {
                return Get(id);
            });
        }

        public VWProductCountInCategory Get(Expression<Func<VWProductCountInCategory, bool>> filter)
        {
            return productCountInCategoryDal.Get(filter);
        }

        public async Task<VWProductCountInCategory> GetAsync(Expression<Func<VWProductCountInCategory, bool>> filter)
        {
            return await Task.Run(() =>
            {
                return Get(filter);
            });
        }

        public List<VWProductCountInCategory> GetAll(Expression<Func<VWProductCountInCategory, bool>> filter = null)
        {
            return filter == null ? productCountInCategoryDal.GetAll() : productCountInCategoryDal.GetAll(filter);
        }

        public async Task<List<VWProductCountInCategory>> GetAllAsync(Expression<Func<VWProductCountInCategory, bool>> filter = null)
        {
            return await Task.Run(() =>
            {
                return GetAll(filter);
            });
        }

        public VWProductCountInCategory GetFirst()
        {
            return productCountInCategoryDal.GetAll().OrderBy(x => x.CategoryID).FirstOrDefault();
        }

        public async Task<VWProductCountInCategory> GetFirstAsync()
        {
            return await Task.Run(() =>
            {
                return GetFirst();
            });
        }

        public VWProductCountInCategory GetLast()
        {
            return productCountInCategoryDal.GetAll().OrderByDescending(x => x.CategoryID).FirstOrDefault();
        }

        public async Task<VWProductCountInCategory> GetLastAsync()
        {
            return await Task.Run(() =>
            {
                return GetLast();
            });
        }

        public VWProductCountInCategory GetNext(int id)
        {
            return productCountInCategoryDal.GetAll(x => x.CategoryID > id).OrderBy(x => x.CategoryID).FirstOrDefault();
        }

        public async Task<VWProductCountInCategory> GetNextAsync(int id)
        {
            return await Task.Run(() =>
            {
                return GetNext(id);
            });
        }

        public VWProductCountInCategory GetPrev(int id)
        {
            return productCountInCategoryDal.GetAll(x => x.CategoryID < id).OrderByDescending(x => x.CategoryID).FirstOrDefault();
        }

        public async Task<VWProductCountInCategory> GetPrevAsync(int id)
        {
            return await Task.Run(() =>
            {
                return GetPrev(id);
            });
        }

    }
}
