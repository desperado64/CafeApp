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
    public class ProductManager : IProductService
    {
        private IProductDal productDal;

        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public void Add(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            productDal.Add(product);
        }

        public async void AddAsync(Product product)
        {
            await Task.Run(() =>
            {
                Add(product);

            });
        }

        public void Delete(Product product)
        {
            if (product != null)
            {
                productDal.Delete(product);
            }
            else
            {
                throw new NullReferenceException("Register Not Found");
            }
        }

        public async void DeleteAsync(Product product)
        {
            await Task.Run(() =>
            {
                Add(product);

            });
        }

        public Product Get(int id)
        {
            return productDal.Get(x => x.ProductID == id);
        }

        public async Task<Product> GetAsync(int id)
        {
            return await Task.Run(() =>
            {
                return Get(id);
            });
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return productDal.Get(filter);
        }

        public async Task<Product> GetAsync(Expression<Func<Product, bool>> filter)
        {
            return await Task.Run(() =>
            {
                return Get(filter);
            });
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return filter == null ? productDal.GetAll() : productDal.GetAll(filter);
        }

        public async Task<List<Product>> GetAllAsync(Expression<Func<Product, bool>> filter = null)
        {
            return await Task.Run(() =>
            {
                return GetAll(filter);
            });
        }

        public Product GetFirst()
        {
            return productDal.GetAll().OrderBy(x => x.ProductID).FirstOrDefault();
        }

        public async Task<Product> GetFirstAsync()
        {
            return await Task.Run(() =>
            {
                return GetFirst();
            });
        }

        public Product GetLast()
        {
            return productDal.GetAll().OrderByDescending(x => x.ProductID).FirstOrDefault();
        }

        public async Task<Product> GetLastAsync()
        {
            return await Task.Run(() =>
            {
                return GetLast();
            });
        }

        public Product GetNext(int id)
        {
            return productDal.GetAll(x => x.ProductID > id).OrderBy(x => x.ProductID).FirstOrDefault();
        }

        public async Task<Product> GetNextAsync(int id)
        {
            return await Task.Run(() =>
            {
                return GetNext(id);
            });
        }

        public Product GetPrev(int id)
        {
            return productDal.GetAll(x => x.ProductID < id).OrderByDescending(x => x.ProductID).FirstOrDefault();
        }

        public async Task<Product> GetPrevAsync(int id)
        {
            return await Task.Run(() =>
            {
                return GetPrev(id);
            });
        }

        public void Update(Product product)
        {
            ValidationTool.Validate(new ProductValidator(), product);
            productDal.Update(product);
        }

        public async void UpdateAsync(Product product)
        {
            await Task.Run(() =>
            {
                Update(product);

            });
        }
    }
}