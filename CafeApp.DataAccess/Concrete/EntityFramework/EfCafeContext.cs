using CafeApp.DataAccess.Concrete.EntityFramework.Mappings.Tables;
using CafeApp.DataAccess.Concrete.EntityFramework.Mappings.Views;
using CafeApp.Entities.Concrete.Tables;
using CafeApp.Entities.Concrete.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeApp.DataAccess.Concrete.EntityFramework
{
    public class EfCafeContext : DbContext
    {
        public string cs = @"Data Source={0}; Initial Catalog=CAFE; User Id=CAFEON; Password=korkut1453;MultipleActiveResultSets=True";
        public EfCafeContext() : base()
        {
            string ip = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("DbSettings")["IP"];
            cs = String.Format(cs, ip);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(cs);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductPropertyMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PropertyMap());

            //Views
            modelBuilder.ApplyConfiguration(new VWProductCountInCategoryMap());
            modelBuilder.ApplyConfiguration(new VWProductInCategoryMap());
            modelBuilder.ApplyConfiguration(new VWProductPropertyMap());

        }
        public DbSet<Category> CATEGORIES { get; set; }
        public DbSet<Product> PRODUCTS { get; set; }
        public DbSet<Property> PROPERTIES { get; set; }
        public DbSet<ProductProperty> PRODUCTPROPERTIES { get; set; }
        public DbSet<User> USERS { get; set; }


        //Views
        public DbSet<VWProductCountInCategory> VWPRODUCTCOUNTINCATEGORIES { get; set; }
        public DbSet<VWProductInCategory> VWPRODUCTSINCATEGORIES { get; set; }
        public DbSet<VWProductProperty> VWPRODUCTPROPERTIES { get; set; }
    }
}
