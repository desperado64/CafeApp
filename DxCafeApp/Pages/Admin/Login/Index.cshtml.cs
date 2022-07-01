using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeApp.Business.Abstract.Tables;
using CafeApp.Business.DependencyResolvers.Ninject;
using CafeApp.Business.Utilities;
using CafeApp.Entities.Concrete.Tables;
using DxCafeApp.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestSharp;

namespace DxCafeApp.Pages.Admin.Login
{
    public class IndexModel : PageModel
    {
        IUserService userService = InstanceFactory.GetInstance<IUserService>();
        public IActionResult OnGet()
        {
            HasAlertPrint("False","");
            mUser = new User();
            return Page();
        }

        private void HasAlertPrint(string status,string message)
        {
            ViewData["IsMessage"] = status;
            ViewData["Message"] = message;
        }

        [BindProperty]
        public User mUser { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                HasAlertPrint("True", "Bad Request");
                CommonConst.mUser = null;
                return Page();
            }

            User user = userService.Get(x => x.UserName.Equals(mUser.UserName));
            if (user!=null)
            {
                if (user.HashPassword.Equals(Encryption.MD5Encode(mUser.SaltPassword)))
                {
                    CommonConst.mUser = user;
                    HasAlertPrint("False", "");
                    SetCookie(user.UserName,user.HashPassword);
                    return RedirectToPage("../Index");
                }
                else
                {
                    HasAlertPrint("True", "Wrong Password");
                    CommonConst.mUser = null;
                    return Page();
                }
                   

            }
            else
            {
                HasAlertPrint("True", "Not Found User");
                CommonConst.mUser = null;
                return Page();
            }

            
        }

        private void SetCookie(string username,string password)
        {
            if (Request.Cookies["DxCafeApp_username"] == null && Request.Cookies["DxCafeApp_password"]==null)
            {
                CookieOptions cookie = new CookieOptions();
                cookie.Expires = DateTime.Now.AddYears(10);
                Response.Cookies.Append(CommonConst.USERNAME_COOKIE_KEY, username, cookie);
                Response.Cookies.Append(CommonConst.PASSWORD_COOKIE_KEY, password, cookie);
            }
        }
    }
}

