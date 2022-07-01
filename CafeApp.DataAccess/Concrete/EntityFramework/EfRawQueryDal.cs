using CafeApp.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp.DataAccess.Concrete.EntityFramework
{
    public class EfRawQueryDal : EfRawOueryBase<EfCafeContext>, IRawQueryDal
    {
    }
}
