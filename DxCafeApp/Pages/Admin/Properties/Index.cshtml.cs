using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeApp.Business.Abstract.Tables;
using CafeApp.Business.DependencyResolvers.Ninject;
using CafeApp.Entities.Concrete.Tables;
using DxCafeApp.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DxCafeApp.Pages.Admin.Properties
{
    public class IndexModel : PageModel
    {

        public IActionResult OnGet()
        {
            return new PageModelFunc().IsLogin(this, "../../Error");
        }

    }
}
