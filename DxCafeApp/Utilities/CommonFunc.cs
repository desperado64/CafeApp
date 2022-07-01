using CafeApp.Business.Abstract.Tables;
using CafeApp.Business.DependencyResolvers.Ninject;
using CafeApp.Entities.Concrete.Tables;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DxCafeApp.Utilities
{
    public class CommonFunc
    {
        public bool IsLogin(HttpContext httpContext)
        {
            if (httpContext.Request.Cookies[CommonConst.USERNAME_COOKIE_KEY] != null && httpContext.Request.Cookies[CommonConst.PASSWORD_COOKIE_KEY] != null)
                return IsLogin(httpContext.Request.Cookies[CommonConst.USERNAME_COOKIE_KEY], httpContext.Request.Cookies[CommonConst.PASSWORD_COOKIE_KEY]);
            else
                return false;

        }

        public bool IsLogin(string username,string password) {
            IUserService userService = InstanceFactory.GetInstance<IUserService>();

            User user = userService.Get(x => x.UserName.Equals(username));
            // return user!=null ? user.HashPassword.Equals(password)? true : false : false;

            if (user!=null)
            {
                if (user.HashPassword.Equals(password))
                {
                    CommonConst.mUser = user;
                    return true;
                }
                else
                {
                    CommonConst.mUser = null;
                    return false;
                }
            }
            else
            {
                CommonConst.mUser = null;
                return false;
            }

        }
    }
}
