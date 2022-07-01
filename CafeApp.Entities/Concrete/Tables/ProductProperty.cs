using CafeApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp.Entities.Concrete.Tables
{
    public class ProductProperty : IEntity
    {
        public int ProductPropertyID{ get; set; }
        public int ProductID { get; set; }
        public int PropertyID { get; set; }
    }
}
