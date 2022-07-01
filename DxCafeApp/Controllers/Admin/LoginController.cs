using CafeApp.Entities.Concrete.Tables;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DxCafeApp.Controllers.Admin
{
    //[Route("Admin/[controller]")]
    public class LoginController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View(new User());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SignIn(User user)
        {
            return Redirect("../Admin/Login/Index");
        }
    }
}
