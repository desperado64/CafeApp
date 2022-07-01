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
    public class VWProductInCategoryManager : IVWProductInCategoryService
    {
        private IVWProductInCategoryDal productInCategory;

        public VWProductInCategoryManager(IVWProductInCategoryDal productInCategory)
        {
            this.productInCategory = productInCategory;
        }

        public VWProductInCategory Get(int id)
        {
            return productInCategory.Get(x => x.ProductID == id);
        }

        public async Task<VWProductInCategory> GetAsync(int id)
        {
            return await Task.Run(() =>
            {
                return Get(id);
            });
        }

        public VWProductInCategory Get(Expression<Func<VWProductInCategory, bool>> filter)
        {
            return productInCategory.Get(filter);
        }

        public async Task<VWProductInCategory> GetAsync(Expression<Func<VWProductInCategory, bool>> filter)
        {
            return await Task.Run(() =>
            {
                return Get(filter);
            });
        }

        public List<VWProductInCategory> GetAll(Expression<Func<VWProductInCategory, bool>> filter = null)
        {
            return filter == null ? productInCategory.GetAll() : productInCategory.GetAll(filter);
        }

        public async Task<List<VWProductInCategory>> GetAllAsync(Expression<Func<VWProductInCategory, bool>> filter = null)
        {
            return await Task.Run(() =>
            {
                return GetAll(filter);
            });
        }

        public VWProductInCategory GetFirst()
        {
            return productInCategory.GetAll().OrderBy(x => x.ProductID).FirstOrDefault();
        }

        public async Task<VWProductInCategory> GetFirstAsync()
        {
            return await Task.Run(() =>
            {
                return GetFirst();
            });
        }

        public VWProductInCategory GetLast()
        {
            return productInCategory.GetAll().OrderByDescending(x => x.ProductID).FirstOrDefault();
        }

        public async Task<VWProductInCategory> GetLastAsync()
        {
            return await Task.Run(() =>
            {
                return GetLast();
            });
        }

        public VWProductInCategory GetNext(int id)
        {
            return productInCategory.GetAll(x => x.ProductID > id).OrderBy(x => x.ProductID).FirstOrDefault();
        }

        public async Task<VWProductInCategory> GetNextAsync(int id)
        {
            return await Task.Run(() =>
            {
                return GetNext(id);
            });
        }

        public VWProductInCategory GetPrev(int id)
        {
            return productInCategory.GetAll(x => x.ProductID < id).OrderByDescending(x => x.ProductID).FirstOrDefault();
        }

        public async Task<VWProductInCategory> GetPrevAsync(int id)
        {
            return await Task.Run(() =>
            {
                return GetPrev(id);
            });
        }

    }
}
