using CafeApp.Business.Abstract.Tables;
using CafeApp.Business.DependencyResolvers.Ninject;
using CafeApp.Entities.Concrete.Tables;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DxCafeApp.Controllers.Admin
{
    [Route("api/[controller]")]
    public class ProductPropertyController : Controller
    {
        IProductPropertyService productPropertyService = InstanceFactory.GetInstance<IProductPropertyService>();

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(productPropertyService.GetAll(), loadOptions);
        }


        [HttpPost]
        public IActionResult Post(string values)
        {
            try
            {
                var productProperty = new ProductProperty();
                JsonConvert.PopulateObject(values, productProperty);
                if (!TryValidateModel(productProperty))
                    return BadRequest(string.Join("; ", ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage)));

                productPropertyService.Add(productProperty);

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
                var productProperty = productPropertyService.Get(key);
                JsonConvert.PopulateObject(values, productProperty);
                if (!TryValidateModel(productProperty))
                    return BadRequest(string.Join("; ", ModelState.Values
                                             .SelectMany(x => x.Errors)
                                             .Select(x => x.ErrorMessage)));

                productPropertyService.Update(productProperty);

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
            var productProperty = productPropertyService.Get(key);
            productPropertyService.Delete(productProperty);

        }
    }
}
