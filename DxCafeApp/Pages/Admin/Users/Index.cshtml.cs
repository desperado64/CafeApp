using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DxCafeApp.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DxCafeApp.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            return new PageModelFunc().IsLogin(this, "../../Error");
        }
    }
}
