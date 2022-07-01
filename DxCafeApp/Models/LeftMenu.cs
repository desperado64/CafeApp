using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DxCafeApp.Models
{
    public class LeftMenu
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Title { get; set; }
        public bool Expanded { get; set; }
        public List<LeftMenu> Items { get; set; }
    }
}
