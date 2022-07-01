using CafeApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Entities.Concrete.Tables
{
    public class Property : IEntity
    {
        public int PropertyID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
