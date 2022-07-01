using CafeApp.Business.Abstract.Tables;
using CafeApp.Business.DependencyResolvers.Ninject;
using CafeApp.Entities.Concrete.Tables;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DxCafeApp.Models;
using DxCafeApp.Utilities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DxCafeApp.Controllers.Admin
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        ICategoryService categoryService = InstanceFactory.GetInstance<ICategoryService>();

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(categoryService.GetAll(), loadOptions);
        }

        [HttpGet("GetLeftMenu")]
        public object GetLeftMenu(DataSourceLoadOptions loadOptions)
        {
            List<LeftMenu> leftMenus = new List<LeftMenu>();

            List<Category> categories = categoryService.GetAll(x=>x.IsDeleted==false);

            List<Category> pCats = categories.Where(x => x.ParentCategoryID == null).ToList();

            foreach (var item in pCats)
            {
                List<Category> subCats = categories.Where(x => x.ParentCategoryID == item.CategoryID).ToList();

                leftMenus.Add(new LeftMenu
                {
                    ID = item.CategoryID,
                    ParentID = -1,
                    Expanded = subCats.Count>0,
                    Title = item.CategoryName,
                    Items = AddSubMenu(categories,item)

                });
            }           
                       

            return DataSourceLoader.Load(leftMenus, loadOptions);
        }

        private List<LeftMenu> AddSubMenu(List<Category> categories, Category category)
        {
            List<LeftMenu> leftMenus = new List<LeftMenu>();
            List<Category> subCats = categories.Where(x => x.ParentCategoryID == category.CategoryID).ToList();

            foreach (var item in subCats)
            {
                List<Category> _subCats = categories.Where(x => x.ParentCategoryID == item.CategoryID).ToList();

                leftMenus.Add(new LeftMenu
                {
                    ID = item.CategoryID,
                    ParentID = item.ParentCategoryID ?? -1,
                    Expanded = subCats.Count > 0,
                    Title = item.CategoryName,
                    Items = _subCats.Count > 0 ? AddSubMenu(categories,item) : new List<LeftMenu>()

                });
            }

            return leftMenus;

        }

        private List<LeftMenu> AddMenu(List<Category> subCats)
        {
            List<LeftMenu> leftMenus = new List<LeftMenu>();

            foreach (var item in subCats)
            {

                leftMenus.Add(new LeftMenu
                {
                    ID = item.CategoryID,
                    ParentID = item.ParentCategoryID ?? -1,
                    Expanded = subCats.Count > 0,
                    Title = item.CategoryName,
                    Items = new List<LeftMenu>()

                });
            }

            return leftMenus;
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            try
            {
                var category = new Category();
                JsonConvert.PopulateObject(values, category);
                category.CreatorUserID = CommonConst.mUser.UserID;
                category.CreatedDate = DateTime.Now;
                if (!TryValidateModel(category))
                    return BadRequest(string.Join("; ", ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage)));

                categoryService.Add(category);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(int key, string values)
        {
            try
            {
                var category = categoryService.Get(key);
                JsonConvert.PopulateObject(values, category);                               
                if (!TryValidateModel(category))
                    return BadRequest(string.Join("; ", ModelState.Values
                                             .SelectMany(x => x.Errors)
                                             .Select(x => x.ErrorMessage)));

                categoryService.Update(category);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        public void Delete(int key)
        {
            var category = categoryService.Get(key);
            categoryService.Delete(category);

        }
    }
}
