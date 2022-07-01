using Currency.Api.Business.Abstract;
using Currency.Api.Business.Concrete;
using Currency.Api.DataAccess.Abstract;
using Currency.Api.DataAccess.Concrete.NewtonSoft;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Api.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDailyCurrencyInfoService>().To<DailyCurrencyInfoManager>().InSingletonScope();
            Bind<IDailyCurrencyInfoDal>().To<NSDailyCurrencyInfoDal>().InSingletonScope();

        }
    }
}
