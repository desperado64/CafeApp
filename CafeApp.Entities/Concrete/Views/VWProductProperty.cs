using CafeApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Entities.Concrete.Views
{
    public class VWProductProperty : IEntity
    {
        public int PropertyID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public int ProductPropertyID { get; set; }
        public int ProductID { get; set; }
    }
}
