using CafeApp.Business.Abstract.Tables;
using CafeApp.Business.DependencyResolvers.Ninject;
using CafeApp.Entities.Concrete.Tables;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
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
    public class ProductController : Controller
    {
        IProductService productService = InstanceFactory.GetInstance<IProductService>();

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(productService.GetAll(), loadOptions);
        }


        [HttpPost]
        public IActionResult Post(string values)
        {
            try
            {
                var product = new Product();
                JsonConvert.PopulateObject(values, product);
                product.CreatorUserID = CommonConst.mUser.UserID;
                product.CreatedDate = DateTime.Now;
                if (!TryValidateModel(product))
                    return BadRequest(string.Join("; ", ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage)));

                productService.Add(product);

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
                var product = productService.Get(key);
                JsonConvert.PopulateObject(values, product);
                if (!TryValidateModel(product))
                    return BadRequest(string.Join("; ", ModelState.Values
                                             .SelectMany(x => x.Errors)
                                             .Select(x => x.ErrorMessage)));

                productService.Update(product);

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
            var product = productService.Get(key);
            productService.Delete(product);

        }
    }
}
