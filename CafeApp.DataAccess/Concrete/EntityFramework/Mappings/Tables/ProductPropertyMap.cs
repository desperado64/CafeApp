using CafeApp.Entities.Concrete.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp.DataAccess.Concrete.EntityFramework.Mappings.Tables
{
    class ProductPropertyMap : IEntityTypeConfiguration<ProductProperty>
    {
        public void Configure(EntityTypeBuilder<ProductProperty> builder)
        {
            builder.ToTable(@"PRODUCTPROPERTIES", @"dbo");
            builder.HasKey(x => x.ProductPropertyID);

            builder.Property(x => x.ProductPropertyID).HasColumnName("PRODUCTPROPERTYID");
            builder.Property(x => x.ProductID).HasColumnName("PRODUCTID");
            builder.Property(x => x.PropertyID).HasColumnName("PROPERTYID");
        }
    }
}
