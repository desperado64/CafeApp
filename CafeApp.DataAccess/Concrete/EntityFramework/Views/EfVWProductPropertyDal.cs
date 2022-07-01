using CafeApp.DataAccess.Abstract.Views;
using CafeApp.Entities.Concrete.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.DataAccess.Concrete.EntityFramework.Views
{
    public class EfVWProductPropertyDal : EfEntityRepositoryBase<VWProductProperty,EfCafeContext>, IVWProductPropertyDal
    {
    }
}
