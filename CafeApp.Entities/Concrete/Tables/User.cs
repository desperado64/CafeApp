using CafeApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp.Entities.Concrete.Tables
{
    public class User : IEntity
    {
		public int UserID { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string UserName { get; set; }
		public string HashPassword { get; set; }
		public string SaltPassword { get; set; }
	}
}
