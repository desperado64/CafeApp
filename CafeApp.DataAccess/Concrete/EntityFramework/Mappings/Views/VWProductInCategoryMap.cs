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
    public class VWProductInCategoryMap : IEntityTypeConfiguration<VWProductInCategory>
    {
        public void Configure(EntityTypeBuilder<VWProductInCategory> builder)
        {
            builder.ToTable(@"VWPRODUCTSINCATEGORIES", @"dbo");
            builder.HasKey(x => x.ProductID);

            builder.Property(x => x.ProductID).HasColumnName("PRODUCTID");
            builder.Property(x => x.ProductName).HasColumnName("PRODUCTNAME");
            builder.Property(x => x.CategoryID).HasColumnName("CATEGORYID");
            builder.Property(x => x.Price).HasColumnName("PRICE");
            builder.Property(x => x.ImagePath).HasColumnName("IMAGEPATH");
            builder.Property(x => x.IsDeleted).HasColumnName("ISDELETED");
            builder.Property(x => x.CreatedDate).HasColumnName("CREATEDDATE");
            builder.Property(x => x.CreatorUserID).HasColumnName("CREATORUSERID");


            builder.Property(x => x.CategoryName).HasColumnName("CATEGORYNAME");
            builder.Property(x => x.ParentCategoryName).HasColumnName("PARENTCATEGORYNAME");
            builder.Property(x => x.ParentCategoryID).HasColumnName("PARENTCATEGORYID");
        }
    }
}