using CafeApp.Entities.Concrete.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp.DataAccess.Concrete.EntityFramework.Mappings.Tables
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(@"CATEGORIES", @"dbo");
            builder.HasKey(x => x.CategoryID);

            builder.Property(x => x.CategoryID).HasColumnName("CATEGORYID");
            builder.Property(x => x.CategoryName).HasColumnName("CATEGORYNAME");
            builder.Property(x => x.ParentCategoryID).HasColumnName("PARENTCATEGORYID");
            builder.Property(x => x.IsDeleted).HasColumnName("ISDELETED");
            builder.Property(x => x.CreatedDate).HasColumnName("CREATEDDATE");
            builder.Property(x => x.CreatorUserID).HasColumnName("CREATORUSERID");
        }
    }
}
