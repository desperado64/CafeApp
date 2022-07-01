using CafeApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Entities.Concrete.Views
{
    public class VWProductInCategory : IEntity
    {
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public int CategoryID { get; set; }
		public decimal Price { get; set; }
		public string ImagePath { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime? CreatedDate { get; set; }
		public int? CreatorUserID { get; set; }



		public string CategoryName { get; set; }
		public string ParentCategoryName { get; set; }
		public int? ParentCategoryID { get; set; }
	}
}
