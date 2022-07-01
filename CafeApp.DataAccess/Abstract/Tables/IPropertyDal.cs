using CafeApp.Entities.Concrete.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.DataAccess.Abstract.Tables
{
    public interface IPropertyDal : IEntityRepository<Property>
    {
    }
}
