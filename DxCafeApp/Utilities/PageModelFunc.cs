using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DxCafeApp.Utilities
{
    public class PageModelFunc
    {
        public ActionResult IsLogin(PageModel pageModel,string path) {

            if (new CommonFunc().IsLogin(pageModel.HttpContext))
            {
                return pageModel.Page();
            }
            else
            {
                return pageModel.RedirectToPage(path, new { Message = "You are not authorized." });
            }

        }
    }
}
