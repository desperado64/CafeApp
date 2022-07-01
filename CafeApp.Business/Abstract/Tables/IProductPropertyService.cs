using CafeApp.Entities.Concrete.Tables;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Business.Abstract.Tables
{
    public interface IProductPropertyService
    {
        List<ProductProperty> GetAll(Expression<Func<ProductProperty, bool>> filter = null);
        ProductProperty Get(int id);
        ProductProperty Get(Expression<Func<ProductProperty, bool>> filter);
        ProductProperty GetLast();
        ProductProperty GetFirst();
        ProductProperty GetNext(int id);
        ProductProperty GetPrev(int id);
        void Add(ProductProperty productProperty);
        void Update(ProductProperty productProperty);
        void Delete(ProductProperty productProperty);

        ///////////// Aync ///////

        Task<List<ProductProperty>> GetAllAsync(Expression<Func<ProductProperty, bool>> filter = null);
        Task<ProductProperty> GetAsync(int id);
        Task<ProductProperty> GetAsync(Expression<Func<ProductProperty, bool>> filter);
        Task<ProductProperty> GetLastAsync();
        Task<ProductProperty> GetFirstAsync();
        Task<ProductProperty> GetNextAsync(int id);
        Task<ProductProperty> GetPrevAsync(int id);
        void AddAsync(ProductProperty productProperty);
        void UpdateAsync(ProductProperty productProperty);
        void DeleteAsync(ProductProperty productProperty);
    }
}
