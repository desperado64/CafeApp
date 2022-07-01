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
    public class PropertyManager : IPropertyService
    {
        private IPropertyDal propertyDal;

        public PropertyManager(IPropertyDal propertyDal)
        {
            this.propertyDal = propertyDal;
        }

        public void Add(Property property)
        {
            ValidationTool.Validate(new PropertyValidator(), property);
            propertyDal.Add(property);
        }

        public async void AddAsync(Property property)
        {
            await Task.Run(() =>
            {
                Add(property);

            });
        }

        public void Delete(Property property)
        {
            if (property != null)
            {
                propertyDal.Delete(property);
            }
            else
            {
                throw new NullReferenceException("Register Not Found");
            }
        }

        public async void DeleteAsync(Property property)
        {
            await Task.Run(() =>
            {
                Add(property);

            });
        }

        public Property Get(int id)
        {
            return propertyDal.Get(x => x.PropertyID == id);
        }

        public async Task<Property> GetAsync(int id)
        {
            return await Task.Run(() =>
            {
                return Get(id);
            });
        }

        public Property Get(Expression<Func<Property, bool>> filter)
        {
            return propertyDal.Get(filter);
        }

        public async Task<Property> GetAsync(Expression<Func<Property, bool>> filter)
        {
            return await Task.Run(() =>
            {
                return Get(filter);
            });
        }

        public List<Property> GetAll(Expression<Func<Property, bool>> filter = null)
        {
            return filter == null ? propertyDal.GetAll() : propertyDal.GetAll(filter);
        }

        public async Task<List<Property>> GetAllAsync(Expression<Func<Property, bool>> filter = null)
        {
            return await Task.Run(() =>
            {
                return GetAll(filter);
            });
        }

        public Property GetFirst()
        {
            return propertyDal.GetAll().OrderBy(x => x.PropertyID).FirstOrDefault();
        }

        public async Task<Property> GetFirstAsync()
        {
            return await Task.Run(() =>
            {
                return GetFirst();
            });
        }

        public Property GetLast()
        {
            return propertyDal.GetAll().OrderByDescending(x => x.PropertyID).FirstOrDefault();
        }

        public async Task<Property> GetLastAsync()
        {
            return await Task.Run(() =>
            {
                return GetLast();
            });
        }

        public Property GetNext(int id)
        {
            return propertyDal.GetAll(x => x.PropertyID > id).OrderBy(x => x.PropertyID).FirstOrDefault();
        }

        public async Task<Property> GetNextAsync(int id)
        {
            return await Task.Run(() =>
            {
                return GetNext(id);
            });
        }

        public Property GetPrev(int id)
        {
            return propertyDal.GetAll(x => x.PropertyID < id).OrderByDescending(x => x.PropertyID).FirstOrDefault();
        }

        public async Task<Property> GetPrevAsync(int id)
        {
            return await Task.Run(() =>
            {
                return GetPrev(id);
            });
        }

        public void Update(Property property)
        {
            ValidationTool.Validate(new PropertyValidator(), property);
            propertyDal.Update(property);
        }

        public async void UpdateAsync(Property property)
        {
            await Task.Run(() =>
            {
                Update(property);

            });
        }
    }
}