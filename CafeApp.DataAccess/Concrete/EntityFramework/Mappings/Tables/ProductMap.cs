using CafeApp.Entities.Concrete.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp.DataAccess.Concrete.EntityFramework.Mappings.Tables
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(@"PRODUCTS", @"dbo");
            builder.HasKey(x => x.ProductID);

            builder.Property(x => x.ProductID).HasColumnName("PRODUCTID");
            builder.Property(x => x.ProductName).HasColumnName("PRODUCTNAME");
            builder.Property(x => x.CategoryID).HasColumnName("CATEGORYID");
            builder.Property(x => x.Price).HasColumnName("PRICE");
            builder.Property(x => x.ImagePath).HasColumnName("IMAGEPATH");
            builder.Property(x => x.IsDeleted).HasColumnName("ISDELETED");
            builder.Property(x => x.CreatedDate).HasColumnName("CREATEDDATE");
            builder.Property(x => x.CreatorUserID).HasColumnName("CREATORUSERID");
        }
    }
}
