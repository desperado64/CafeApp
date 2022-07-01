using CafeApp.Entities.Concrete.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Business.Abstract.Tables
{
    public interface IPropertyService
    {
        List<Property> GetAll(Expression<Func<Property, bool>> filter = null);
        Property Get(int id);
        Property Get(Expression<Func<Property, bool>> filter);
        Property GetLast();
        Property GetFirst();
        Property GetNext(int id);
        Property GetPrev(int id);
        void Add(Property property);
        void Update(Property property);
        void Delete(Property property);

        ///////////// Aync ///////

        Task<List<Property>> GetAllAsync(Expression<Func<Property, bool>> filter = null);
        Task<Property> GetAsync(int id);
        Task<Property> GetAsync(Expression<Func<Property, bool>> filter);
        Task<Property> GetLastAsync();
        Task<Property> GetFirstAsync();
        Task<Property> GetNextAsync(int id);
        Task<Property> GetPrevAsync(int id);
        void AddAsync(Property property);
        void UpdateAsync(Property property);
        void DeleteAsync(Property property);
    }
}
