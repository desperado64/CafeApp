using CafeApp.Entities.Concrete.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp.DataAccess.Concrete.EntityFramework.Mappings.Tables
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(@"USERS", @"dbo");
            builder.HasKey(x => x.UserID);

            builder.Property(x => x.UserID).HasColumnName("USERID");
            builder.Property(x => x.Name).HasColumnName("NAME");
            builder.Property(x => x.Surname).HasColumnName("SURNAME");
            builder.Property(x => x.UserName).HasColumnName("USERNAME");
            builder.Property(x => x.HashPassword).HasColumnName("HASHPASSWORD");
            builder.Property(x => x.SaltPassword).HasColumnName("SALTPASSWORD");
        }
    }
}
