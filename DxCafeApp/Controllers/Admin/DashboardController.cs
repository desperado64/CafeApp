using CafeApp.Business.Abstract.Tables;
using CafeApp.Business.Abstract.Views;
using CafeApp.Business.DependencyResolvers.Ninject;
using Currency.Api.Business.Abstract;
using Currency.Api.Entities.Concrete;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using DxCafeApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


using InstanceFactoryApi = Currency.Api.Business.DependencyResolvers.Ninject.InstanceFactory;

namespace DxCafeApp.Controllers.Admin
{
    [Route("api/[controller]")]
    public class DashboardController : Controller
    {
        IVWProductCountInCategoryService productCountInCategoryService = InstanceFactory.GetInstance<IVWProductCountInCategoryService>();
        IVWProductInCategoryService productInCategoryService = InstanceFactory.GetInstance<IVWProductInCategoryService>();
        IDailyCurrencyInfoService dailyCurrencyInfoService = InstanceFactoryApi.GetInstance<IDailyCurrencyInfoService>();

        [HttpGet]
        public object Pie(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(productCountInCategoryService.GetAll(), loadOptions);
        }


        [HttpGet("DailyPrices")]
        public IActionResult DailyPrices()
        {
            try
            {
                List<TcmbCurrency> currencies = dailyCurrencyInfoService.GetCurrencies().Currencies;
                TcmbCurrency tcmbCurrency = currencies.Where(x => x.CurrencyName.Equals("US DOLLAR")).FirstOrDefault();

                List<DailyPrice> dailyPrices = productInCategoryService.GetAll().Select(x => new DailyPrice
                {
                    ProductID = x.ProductID,
                    ProductName = x.ProductName,
                    CategoryID = x.CategoryID,
                    Price = x.Price,
                    ImagePath = x.ImagePath,
                    IsDeleted = x.IsDeleted,
                    CreatedDate = x.CreatedDate,
                    CreatorUserID = x.CreatorUserID,
                    CategoryName = x.CategoryName,
                    ParentCategoryID = x.ParentCategoryID,
                    ParentCategoryName = x.ParentCategoryName,
                    PriceTL = decimal.Parse(tcmbCurrency.ForexSelling ?? "1".Replace(',', '.'), CultureInfo.InvariantCulture) * x.Price

                }).ToList();

                return Ok(dailyPrices);
            }
            catch 
            {
                return BadRequest(new List<DailyPrice>());
            }
        }
    }
}
