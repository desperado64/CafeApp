using Currency.Api.DataAccess.Abstract;
using Currency.Api.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Api.DataAccess.Concrete.NewtonSoft
{
    public class NSDailyCurrencyInfoDal : NSFirstEntityRepositoryBase<DailyCurrencyInfo>, IDailyCurrencyInfoDal
    {
    }
}
