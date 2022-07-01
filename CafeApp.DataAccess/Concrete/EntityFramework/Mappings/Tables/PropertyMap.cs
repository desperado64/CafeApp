using CafeApp.Entities.Concrete.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.DataAccess.Concrete.EntityFramework.Mappings.Tables
{
    public class PropertyMap : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable(@"PROPERTIES", @"dbo");
            builder.HasKey(x => x.PropertyID);

            builder.Property(x => x.PropertyID).HasColumnName("PROPERTYID");
            builder.Property(x => x.Key).HasColumnName("KEY");
            builder.Property(x => x.Value).HasColumnName("VALUE");
        }
    }
}
