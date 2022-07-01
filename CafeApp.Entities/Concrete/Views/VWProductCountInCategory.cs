using CafeApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Entities.Concrete.Views
{
    public class VWProductCountInCategory : IEntity
    {
        public int CategoryID{ get; set; }
        public string CategoryName { get; set; }
        public int ProductCount { get; set; }
    }
}
