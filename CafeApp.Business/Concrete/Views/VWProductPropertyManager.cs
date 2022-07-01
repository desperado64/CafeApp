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
    public class VWProductPropertyManager: IVWProductPropertyService
    {
        private IVWProductPropertyDal productProperty;

        public VWProductPropertyManager(IVWProductPropertyDal productProperty)
        {
            this.productProperty = productProperty;
        }

        public VWProductProperty Get(int id)
        {
            return productProperty.Get(x => x.ProductID == id);
        }

        public async Task<VWProductProperty> GetAsync(int id)
        {
            return await Task.Run(() =>
            {
                return Get(id);
            });
        }

        public VWProductProperty Get(Expression<Func<VWProductProperty, bool>> filter)
        {
            return productProperty.Get(filter);
        }

        public async Task<VWProductProperty> GetAsync(Expression<Func<VWProductProperty, bool>> filter)
        {
            return await Task.Run(() =>
            {
                return Get(filter);
            });
        }

        public List<VWProductProperty> GetAll(Expression<Func<VWProductProperty, bool>> filter = null)
        {
            return filter == null ? productProperty.GetAll() : productProperty.GetAll(filter);
        }

        public async Task<List<VWProductProperty>> GetAllAsync(Expression<Func<VWProductProperty, bool>> filter = null)
        {
            return await Task.Run(() =>
            {
                return GetAll(filter);
            });
        }

        public VWProductProperty GetFirst()
        {
            return productProperty.GetAll().OrderBy(x => x.ProductID).FirstOrDefault();
        }

        public async Task<VWProductProperty> GetFirstAsync()
        {
            return await Task.Run(() =>
            {
                return GetFirst();
            });
        }

        public VWProductProperty GetLast()
        {
            return productProperty.GetAll().OrderByDescending(x => x.ProductID).FirstOrDefault();
        }

        public async Task<VWProductProperty> GetLastAsync()
        {
            return await Task.Run(() =>
            {
                return GetLast();
            });
        }

        public VWProductProperty GetNext(int id)
        {
            return productProperty.GetAll(x => x.ProductID > id).OrderBy(x => x.ProductID).FirstOrDefault();
        }

        public async Task<VWProductProperty> GetNextAsync(int id)
        {
            return await Task.Run(() =>
            {
                return GetNext(id);
            });
        }

        public VWProductProperty GetPrev(int id)
        {
            return productProperty.GetAll(x => x.ProductID < id).OrderByDescending(x => x.ProductID).FirstOrDefault();
        }

        public async Task<VWProductProperty> GetPrevAsync(int id)
        {
            return await Task.Run(() =>
            {
                return GetPrev(id);
            });
        }

    }
}
