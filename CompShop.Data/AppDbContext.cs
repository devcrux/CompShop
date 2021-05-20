using CompShop.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompShop.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Basket> ShoppingBasket { get; set; }


        /// <summary>
        /// Using the Fluent API style to configure the database tables for constraints 
        /// in order to check for duplicate
        /// </summary>
        /// <param name="builder">The builder object <see cref="ModelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Laptop>()
                .HasIndex(x => x.Name)
                .IsUnique();

            builder.Entity<Config>()
                .HasIndex(x => x.Attribute)
                .IsUnique();

            //builder.Entity<Basket>()
            //    .HasIndex(x => x.Specifications.Distinct())
            //    .IsUnique();

        }

    }
}
