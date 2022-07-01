using CafeApp.DataAccess.Abstract.Tables;
using CafeApp.Entities.Concrete.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.DataAccess.Concrete.EntityFramework.Tables
{
    public class EfPropertyDal : EfEntityRepositoryBase<Property, EfCafeContext>, IPropertyDal
    {
    }
}
