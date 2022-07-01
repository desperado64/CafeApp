using CafeApp.Entities.Concrete.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.DataAccess.Concrete.EntityFramework.Mappings.Views
{
    public class VWProductCountInCategoryMap : IEntityTypeConfiguration<VWProductCountInCategory>
    {
        public void Configure(EntityTypeBuilder<VWProductCountInCategory> builder)
        {
            builder.ToTable(@"VWPRODUCTCOUNTINCATEGORIES", @"dbo");
            builder.HasKey(x => x.CategoryID);

            builder.Property(x => x.CategoryID).HasColumnName("CATEGORYID");
            builder.Property(x => x.CategoryName).HasColumnName("CATEGORYNAME");
            builder.Property(x => x.ProductCount).HasColumnName("PRODUCTCOUNT");

        }
    }
}