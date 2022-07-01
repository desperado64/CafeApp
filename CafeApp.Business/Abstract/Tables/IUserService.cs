using CafeApp.Entities.Concrete.Tables;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Business.Abstract.Tables
{
    public interface IUserService
    {
        List<User> GetAll(Expression<Func<User, bool>> filter = null);
        User Get(int id);
        User Get(Expression<Func<User, bool>> filter);
        User GetLast();
        User GetFirst();
        User GetNext(int id);
        User GetPrev(int id);
        void Add(User user);
        void Update(User user);
        void Delete(User user);

        ///////////// Aync ///////

        Task<List<User>> GetAllAsync(Expression<Func<User, bool>> filter = null);
        Task<User> GetAsync(int id);
        Task<User> GetAsync(Expression<Func<User, bool>> filter);
        Task<User> GetLastAsync();
        Task<User> GetFirstAsync();
        Task<User> GetNextAsync(int id);
        Task<User> GetPrevAsync(int id);
        void AddAsync(User user);
        void UpdateAsync(User user);
        void DeleteAsync(User user);
    }
}
