using CafeApp.DataAccess.Abstract.Tables;
using CafeApp.Entities.Concrete.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp.DataAccess.Concrete.EntityFramework.Tables
{
    public class EfProductDal : EfEntityRepositoryBase<Product, EfCafeContext>, IProductDal
    {
    }
}
