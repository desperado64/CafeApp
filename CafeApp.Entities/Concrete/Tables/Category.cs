using CafeApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp.Entities.Concrete.Tables
{
    public class Category : IEntity
    {
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }
		public int? ParentCategoryID { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime? CreatedDate { get; set; }
		public int? CreatorUserID { get; set; }
	}
}
