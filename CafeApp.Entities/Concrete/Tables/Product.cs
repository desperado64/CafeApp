using CafeApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp.Entities.Concrete.Tables
{
    public class Product :IEntity
    {
		public int ProductID { get; set; }
		public string ProductName { get; set; }
		public int CategoryID { get; set; }
		public decimal Price { get; set; }
		public string ImagePath { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime? CreatedDate { get; set; }
		public int? CreatorUserID { get; set; }
	}
}
