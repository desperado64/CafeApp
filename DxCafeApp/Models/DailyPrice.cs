using CafeApp.Entities.Concrete.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DxCafeApp.Models
{
    public class DailyPrice : VWProductInCategory
    {
        public decimal PriceTL { get; set; }
    }
}
