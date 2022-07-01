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
    public class PropertyController : Controller
    {
        IPropertyService propertyService = InstanceFactory.GetInstance<IPropertyService>();

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(propertyService.GetAll(), loadOptions);
        }


        [HttpPost]
        public IActionResult Post(string values)
        {
            try
            {
                var property = new Property();
                JsonConvert.PopulateObject(values, property);
                if (!TryValidateModel(property))
                    return BadRequest(string.Join("; ", ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage)));

                propertyService.Add(property);

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
                var property = propertyService.Get(key);
                JsonConvert.PopulateObject(values, property);
                if (!TryValidateModel(property))
                    return BadRequest(string.Join("; ", ModelState.Values
                                             .SelectMany(x => x.Errors)
                                             .Select(x => x.ErrorMessage)));

                propertyService.Update(property);

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
            var property = propertyService.Get(key);
            propertyService.Delete(property);

        }
    }
}
