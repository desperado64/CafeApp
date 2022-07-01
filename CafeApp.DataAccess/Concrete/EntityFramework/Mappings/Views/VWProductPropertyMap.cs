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
    public class VWProductPropertyMap : IEntityTypeConfiguration<VWProductProperty>
    {
        public void Configure(EntityTypeBuilder<VWProductProperty> builder)
        {
            builder.ToTable(@"VWPRODUCTPROPERTIES", @"dbo");
            builder.HasKey(x => x.ProductID);

            builder.Property(x => x.PropertyID).HasColumnName("PROPERTYID");
            builder.Property(x => x.Key).HasColumnName("KEY");
            builder.Property(x => x.Value).HasColumnName("VALUE");

            builder.Property(x => x.ProductPropertyID).HasColumnName("PRODUCTPROPERTYID");
            builder.Property(x => x.ProductID).HasColumnName("PRODUCTID");

        }
    }
}