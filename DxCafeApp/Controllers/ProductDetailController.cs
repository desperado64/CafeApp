using CafeApp.Business.Abstract.Tables;
using CafeApp.Business.Abstract.Views;
using CafeApp.Business.DependencyResolvers.Ninject;
using CafeApp.Entities.Concrete.Views;
using Currency.Api.Business.Abstract;
using Currency.Api.Entities.Concrete;
using DxCafeApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using InstanceFactoryApi = Currency.Api.Business.DependencyResolvers.Ninject.InstanceFactory;

namespace DxCafeApp.Controllers
{
    [Route("[controller]")]
    public class ProductDetailController : Controller
    {
        IVWProductInCategoryService productInCategoryService = InstanceFactory.GetInstance<IVWProductInCategoryService>();
        IVWProductPropertyService productPropertyService = InstanceFactory.GetInstance<IVWProductPropertyService>();
        IDailyCurrencyInfoService dailyCurrencyInfoService = InstanceFactoryApi.GetInstance<IDailyCurrencyInfoService>();

        [HttpGet("{id}")]
        public IActionResult Index(int id)
        {
            dynamic mymodel = new ExpandoObject();
            VWProductInCategory productInCategory = productInCategoryService.Get(id);
            mymodel.Product = productInCategory;
            List<VWProductProperty> vWProductProperties = productPropertyService.GetAll(x => x.PropertyID == id);
            List<string> keys = vWProductProperties.Select(x => x.Key).Distinct().ToList();

            List<BasicProperty> basicProperties = new List<BasicProperty>();
            foreach (var key in keys)
            {
                basicProperties.Add(new BasicProperty
                {
                    Key = key,
                    Value = String.Join(", ",vWProductProperties.Where(x => x.Key.Equals(key)).Select(x => x.Value).ToList())
                });
            }

            mymodel.Properties = basicProperties;
            mymodel.Currencies = CalcCurrencies(productInCategory.Price); 

            return View(mymodel);
        }

        private List<BasicProperty> CalcCurrencies(decimal price)
        {
            List<TcmbCurrency> currencies = dailyCurrencyInfoService.GetCurrencies().Currencies;
            TcmbCurrency dolar = currencies.Where(x => x.CurrencyName.Equals("US DOLLAR")).FirstOrDefault();
            List<BasicProperty> basicProperties = new List<BasicProperty>();
            basicProperties.Add(new BasicProperty { Key = "TRY", Value = (decimal.Parse(dolar.ForexSelling ?? "1".Replace(',', '.'), CultureInfo.InvariantCulture) * price).ToString("N2") });
            foreach (var item in currencies)
            {
                AddCurrency(price, dolar, basicProperties, item, "EURO");
                AddCurrency(price, dolar, basicProperties, item, "POUND STERLING");
                AddCurrency(price, dolar, basicProperties, item, "SWISS FRANK");
                AddCurrency(price, dolar, basicProperties, item, "JAPENESE YEN");
                AddCurrency(price, dolar, basicProperties, item, "RUSSIAN ROUBLE");
            }

            return basicProperties;
        }

        private static void AddCurrency(decimal price, TcmbCurrency dolar, List<BasicProperty> basicProperties, TcmbCurrency item, string v)
        {
            if (item.CurrencyName.Equals(v))
            {
                basicProperties.Add(new BasicProperty { Key = v, Value = CalcPrice(dolar, item, price).ToString("N2") });
            }
        }

        private static decimal CalcPrice(TcmbCurrency dolar, TcmbCurrency item, decimal price)
        {
            return (price * ((decimal.Parse(dolar.ForexBuying ?? "1".Replace(',', '.'), CultureInfo.InvariantCulture) + decimal.Parse(dolar.ForexSelling ?? "1".Replace(',', '.'), CultureInfo.InvariantCulture)) / 2)
                    /
                    ((decimal.Parse(item.ForexBuying ?? "1".Replace(',', '.'), CultureInfo.InvariantCulture) + decimal.Parse(item.ForexSelling ?? "1".Replace(',', '.'), CultureInfo.InvariantCulture)) / 2));
        }
    }
}
