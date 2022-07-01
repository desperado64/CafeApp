using CafeApp.Business.Abstract;
using CafeApp.Business.Abstract.Tables;
using CafeApp.Business.Abstract.Views;
using CafeApp.Business.Concrete;
using CafeApp.Business.Concrete.Tables;
using CafeApp.Business.Concrete.Views;
using CafeApp.DataAccess.Abstract;
using CafeApp.DataAccess.Abstract.Tables;
using CafeApp.DataAccess.Abstract.Views;
using CafeApp.DataAccess.Concrete.EntityFramework;
using CafeApp.DataAccess.Concrete.EntityFramework.Tables;
using CafeApp.DataAccess.Concrete.EntityFramework.Views;
using Ninject.Modules;

namespace CafeApp.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();

            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

            Bind<IProductPropertyService>().To<ProductPropertyManager>().InSingletonScope();
            Bind<IProductPropertyDal>().To<EfProductPropertyDal>().InSingletonScope();

            Bind<IPropertyService>().To<PropertyManager>().InSingletonScope();
            Bind<IPropertyDal>().To<EfPropertyDal>().InSingletonScope();


            //Views
            Bind<IVWProductCountInCategoryService>().To<VWProductCountInCategoryManager>().InSingletonScope();
            Bind<IVWProductCountInCategoryDal>().To<EfVWProductCountInCategoryDal>().InSingletonScope();

            Bind<IVWProductInCategoryService>().To<VWProductInCategoryManager>().InSingletonScope();
            Bind<IVWProductInCategoryDal>().To<EfVWProductInCategoryDal>().InSingletonScope();

            Bind<IVWProductPropertyService>().To<VWProductPropertyManager>().InSingletonScope();
            Bind<IVWProductPropertyDal>().To<EfVWProductPropertyDal>().InSingletonScope();


            //RawQuery
            Bind<IRawQueryService>().To<RawQueryManager>().InSingletonScope();
            Bind<IRawQueryDal>().To<EfRawQueryDal>().InSingletonScope();
        }
    }
}