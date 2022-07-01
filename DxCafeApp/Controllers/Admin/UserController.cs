using CafeApp.Business.Abstract.Tables;
using CafeApp.Business.DependencyResolvers.Ninject;
using CafeApp.Business.Utilities;
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
    public class UserController : Controller
    {
        IUserService userService = InstanceFactory.GetInstance<IUserService>();

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(userService.GetAll(), loadOptions);
        }

        [HttpPost]
        public IActionResult Post(string values)
        {
            try
            {
                var newUser = new User();
                JsonConvert.PopulateObject(values, newUser);
                newUser.HashPassword = Encryption.MD5Encode(newUser.SaltPassword);
                if (!TryValidateModel(newUser))
                    return BadRequest(string.Join("; ", ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage)));

                userService.Add(newUser);

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
                var user = userService.Get(key);
                JsonConvert.PopulateObject(values, user);
                user.HashPassword = Encryption.MD5Encode(user.SaltPassword);
                if (!TryValidateModel(user))
                    return BadRequest(string.Join("; ", ModelState.Values
                                             .SelectMany(x => x.Errors)
                                             .Select(x => x.ErrorMessage)));

                userService.Update(user);

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
            var user = userService.Get(key);
            userService.Delete(user);
           
        }
    }
}
