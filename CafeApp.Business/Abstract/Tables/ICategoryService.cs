using CafeApp.Entities.Concrete.Tables;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Business.Abstract.Tables
{
    public interface ICategoryService
    {
        List<Category> GetAll(Expression<Func<Category, bool>> filter = null);
        Category Get(int id);
        Category Get(Expression<Func<Category, bool>> filter);
        Category GetLast();
        Category GetFirst();
        Category GetNext(int id);
        Category GetPrev(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);

        ///////////// Aync ///////

        Task<List<Category>> GetAllAsync(Expression<Func<Category, bool>> filter = null);
        Task<Category> GetAsync(int id);
        Task<Category> GetAsync(Expression<Func<Category, bool>> filter);
        Task<Category> GetLastAsync();
        Task<Category> GetFirstAsync();
        Task<Category> GetNextAsync(int id);
        Task<Category> GetPrevAsync(int id);
        void AddAsync(Category category);
        void UpdateAsync(Category category);
        void DeleteAsync(Category category);
    }
}
