using CafeApp.Entities.Concrete.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp.DataAccess.Abstract.Tables
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
    }
}
