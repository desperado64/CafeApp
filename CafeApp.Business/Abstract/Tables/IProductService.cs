using CafeApp.Entities.Concrete.Tables;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Business.Abstract.Tables
{
    public interface IProductService
    {
        List<Product> GetAll(Expression<Func<Product, bool>> filter = null);
        Product Get(int id);
        Product Get(Expression<Func<Product, bool>> filter);
        Product GetLast();
        Product GetFirst();
        Product GetNext(int id);
        Product GetPrev(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        ///////////// Aync ///////

        Task<List<Product>> GetAllAsync(Expression<Func<Product, bool>> filter = null);
        Task<Product> GetAsync(int id);
        Task<Product> GetAsync(Expression<Func<Product, bool>> filter);
        Task<Product> GetLastAsync();
        Task<Product> GetFirstAsync();
        Task<Product> GetNextAsync(int id);
        Task<Product> GetPrevAsync(int id);
        void AddAsync(Product product);
        void UpdateAsync(Product product);
        void DeleteAsync(Product product);
    }
}
