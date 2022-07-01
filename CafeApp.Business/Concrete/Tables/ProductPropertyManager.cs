using CafeApp.Business.Abstract.Tables;
using CafeApp.Business.Utilities;
using CafeApp.Business.ValidationRules.FluentValidation;
using CafeApp.DataAccess.Abstract.Tables;
using CafeApp.Entities.Concrete.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Business.Concrete.Tables
{
    public class ProductPropertyManager : IProductPropertyService
    {
        private IProductPropertyDal productPropertyDal;

        public ProductPropertyManager(IProductPropertyDal productPropertyDal)
        {
            this.productPropertyDal = productPropertyDal;
        }

        public void Add(ProductProperty productProperty)
        {
            ValidationTool.Validate(new ProductPropertyValidator(), productProperty);
            productPropertyDal.Add(productProperty);
        }

        public async void AddAsync(ProductProperty productProperty)
        {
            await Task.Run(() =>
            {
                Add(productProperty);

            });
        }

        public void Delete(ProductProperty productProperty)
        {
            if (productProperty != null)
            {
                productPropertyDal.Delete(productProperty);
            }
            else
            {
                throw new NullReferenceException("Register Not Found");
            }
        }

        public async void DeleteAsync(ProductProperty productProperty)
        {
            await Task.Run(() =>
            {
                Add(productProperty);

            });
        }

        public ProductProperty Get(int id)
        {
            return productPropertyDal.Get(x => x.ProductPropertyID == id);
        }

        public async Task<ProductProperty> GetAsync(int id)
        {
            return await Task.Run(() =>
            {
                return Get(id);
            });
        }

        public ProductProperty Get(Expression<Func<ProductProperty, bool>> filter)
        {
            return productPropertyDal.Get(filter);
        }

        public async Task<ProductProperty> GetAsync(Expression<Func<ProductProperty, bool>> filter)
        {
            return await Task.Run(() =>
            {
                return Get(filter);
            });
        }

        public List<ProductProperty> GetAll(Expression<Func<ProductProperty, bool>> filter = null)
        {
            return filter == null ? productPropertyDal.GetAll() : productPropertyDal.GetAll(filter);
        }

        public async Task<List<ProductProperty>> GetAllAsync(Expression<Func<ProductProperty, bool>> filter = null)
        {
            return await Task.Run(() =>
            {
                return GetAll(filter);
            });
        }

        public ProductProperty GetFirst()
        {
            return productPropertyDal.GetAll().OrderBy(x => x.ProductPropertyID).FirstOrDefault();
        }

        public async Task<ProductProperty> GetFirstAsync()
        {
            return await Task.Run(() =>
            {
                return GetFirst();
            });
        }

        public ProductProperty GetLast()
        {
            return productPropertyDal.GetAll().OrderByDescending(x => x.ProductPropertyID).FirstOrDefault();
        }

        public async Task<ProductProperty> GetLastAsync()
        {
            return await Task.Run(() =>
            {
                return GetLast();
            });
        }

        public ProductProperty GetNext(int id)
        {
            return productPropertyDal.GetAll(x => x.ProductPropertyID > id).OrderBy(x => x.ProductPropertyID).FirstOrDefault();
        }

        public async Task<ProductProperty> GetNextAsync(int id)
        {
            return await Task.Run(() =>
            {
                return GetNext(id);
            });
        }

        public ProductProperty GetPrev(int id)
        {
            return productPropertyDal.GetAll(x => x.ProductPropertyID < id).OrderByDescending(x => x.ProductPropertyID).FirstOrDefault();
        }

        public async Task<ProductProperty> GetPrevAsync(int id)
        {
            return await Task.Run(() =>
            {
                return GetPrev(id);
            });
        }

        public void Update(ProductProperty productProperty)
        {
            ValidationTool.Validate(new ProductPropertyValidator(), productProperty);
            productPropertyDal.Update(productProperty);
        }

        public async void UpdateAsync(ProductProperty productProperty)
        {
            await Task.Run(() =>
            {
                Update(productProperty);

            });
        }
    }
}