using CafeApp.Business.Abstract.Tables;
using CafeApp.Business.Abstract.Views;
using CafeApp.Business.DependencyResolvers.Ninject;
using CafeApp.Entities.Concrete.Tables;
using CafeApp.Entities.Concrete.Views;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace DxCafeApp.Controllers
{
 
    public class HomeController : Controller
    {
        IProductService productService = InstanceFactory.GetInstance<IProductService>();
        ICategoryService categoryService = InstanceFactory.GetInstance<ICategoryService>();
        IVWProductInCategoryService productInCategoryService = InstanceFactory.GetInstance<IVWProductInCategoryService>();

        [Route("")]
        [Route("Home")]
        public IActionResult Index()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.Products = productInCategoryService.GetAll();
            return View(mymodel);
        }

        [Route("Home/{id:int}")]
        public IActionResult Index(int id)
        {
            dynamic mymodel = new ExpandoObject();            
            mymodel.Products = GetProducts(id);
            return View(mymodel);
        }

        List<int> catIds = new List<int>();
        private dynamic GetProducts(int id)
        {            
            AddCatIds(id);
            List<int> tempCatIDs = catIds.Distinct().ToList();
            return productInCategoryService.GetAll(x => tempCatIDs.Contains(x.CategoryID));

        }

        private void AddCatIds(int id)
        {
            catIds.Add(id);
            List<int> ids = categoryService.GetAll(x => x.ParentCategoryID == id && x.IsDeleted == false).Select(x=>x.CategoryID).Distinct().ToList();
            foreach (var item in ids)
            {                
                AddCatIds(item);
            }
        }
    }
}
