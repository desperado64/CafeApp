using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DxCafeApp.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DxCafeApp.Pages.Admin.Logout
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            CommonConst.mUser = null;
            HasAlertPrint("True", "Deleted All Cookies");
            DeleteCookies();
            return Page();
        }

        private void DeleteCookies()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
        }

        private void HasAlertPrint(string status, string message)
        {
            ViewData["IsMessage"] = status;
            ViewData["Message"] = message;
        }
    }
}
