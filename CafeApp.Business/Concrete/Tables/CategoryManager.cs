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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            ValidationTool.Validate(new CategoryValidator(), category);
            categoryDal.Add(category);
        }

        public async void AddAsync(Category category)
        {
            await Task.Run(() =>
            {
                Add(category);

            });
        }

        public void Delete(Category category)
        {
            if (category != null)
            {
                categoryDal.Delete(category);
            }
            else
            {
                throw new NullReferenceException("Register Not Found");
            }
        }

        public async void DeleteAsync(Category category)
        {
            await Task.Run(() =>
            {
                Add(category);

            });
        }

        public Category Get(int id)
        {
            return categoryDal.Get(x => x.CategoryID == id);
        }

        public async Task<Category> GetAsync(int id)
        {
            return await Task.Run(() =>
            {
                return Get(id);
            });
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            return categoryDal.Get(filter);
        }

        public async Task<Category> GetAsync(Expression<Func<Category, bool>> filter)
        {
            return await Task.Run(() =>
            {
                return Get(filter);
            });
        }

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return filter == null ? categoryDal.GetAll() : categoryDal.GetAll(filter);
        }

        public async Task<List<Category>> GetAllAsync(Expression<Func<Category, bool>> filter = null)
        {
            return await Task.Run(() =>
            {
                return GetAll(filter);
            });
        }

        public Category GetFirst()
        {
            return categoryDal.GetAll().OrderBy(x => x.CategoryID).FirstOrDefault();
        }

        public async Task<Category> GetFirstAsync()
        {
            return await Task.Run(() =>
            {
                return GetFirst();
            });
        }

        public Category GetLast()
        {
            return categoryDal.GetAll().OrderByDescending(x => x.CategoryID).FirstOrDefault();
        }

        public async Task<Category> GetLastAsync()
        {
            return await Task.Run(() =>
            {
                return GetLast();
            });
        }

        public Category GetNext(int id)
        {
            return categoryDal.GetAll(x => x.CategoryID > id).OrderBy(x => x.CategoryID).FirstOrDefault();
        }

        public async Task<Category> GetNextAsync(int id)
        {
            return await Task.Run(() =>
            {
                return GetNext(id);
            });
        }

        public Category GetPrev(int id)
        {
            return categoryDal.GetAll(x => x.CategoryID < id).OrderByDescending(x => x.CategoryID).FirstOrDefault();
        }

        public async Task<Category> GetPrevAsync(int id)
        {
            return await Task.Run(() =>
            {
                return GetPrev(id);
            });
        }

        public void Update(Category category)
        {
            ValidationTool.Validate(new CategoryValidator(), category);
            categoryDal.Update(category);
        }

        public async void UpdateAsync(Category category)
        {
            await Task.Run(() =>
            {
                Update(category);

            });
        }
    }
}