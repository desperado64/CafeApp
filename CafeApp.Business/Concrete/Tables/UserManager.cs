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
    public class UserManager : IUserService
    {
        private IUserDal userDal;

        public UserManager(IUserDal userDal)
        {
            this.userDal = userDal;
        }

        public void Add(User user)
        {
            ValidationTool.Validate(new UserValidator(), user);
            userDal.Add(user);
        }

        public async void AddAsync(User user)
        {
            await Task.Run(() =>
            {
                Add(user);

            });
        }

        public void Delete(User user)
        {
            if (user != null)
            {
                userDal.Delete(user);
            }
            else
            {
                throw new NullReferenceException("Register Not Found");
            }
        }

        public async void DeleteAsync(User user)
        {
            await Task.Run(() =>
            {
                Add(user);

            });
        }

        public User Get(int id)
        {
            return userDal.Get(x => x.UserID == id);
        }

        public async Task<User> GetAsync(int id)
        {
            return await Task.Run(() =>
            {
                return Get(id);
            });
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            return userDal.Get(filter);
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> filter)
        {
            return await Task.Run(() =>
            {
                return Get(filter);
            });
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return filter == null ? userDal.GetAll() : userDal.GetAll(filter);
        }

        public async Task<List<User>> GetAllAsync(Expression<Func<User, bool>> filter = null)
        {
            return await Task.Run(() =>
            {
                return GetAll(filter);
            });
        }

        public User GetFirst()
        {
            return userDal.GetAll().OrderBy(x => x.UserID).FirstOrDefault();
        }

        public async Task<User> GetFirstAsync()
        {
            return await Task.Run(() =>
            {
                return GetFirst();
            });
        }

        public User GetLast()
        {
            return userDal.GetAll().OrderByDescending(x => x.UserID).FirstOrDefault();
        }

        public async Task<User> GetLastAsync()
        {
            return await Task.Run(() =>
            {
                return GetLast();
            });
        }

        public User GetNext(int id)
        {
            return userDal.GetAll(x => x.UserID > id).OrderBy(x => x.UserID).FirstOrDefault();
        }

        public async Task<User> GetNextAsync(int id)
        {
            return await Task.Run(() =>
            {
                return GetNext(id);
            });
        }

        public User GetPrev(int id)
        {
            return userDal.GetAll(x => x.UserID < id).OrderByDescending(x => x.UserID).FirstOrDefault();
        }

        public async Task<User> GetPrevAsync(int id)
        {
            return await Task.Run(() =>
            {
                return GetPrev(id);
            });
        }

        public void Update(User user)
        {
            ValidationTool.Validate(new UserValidator(), user);
            userDal.Update(user);
        }

        public async void UpdateAsync(User user)
        {
            await Task.Run(() =>
            {
                Update(user);

            });
        }
    }
}