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
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<Config> Configs { get; set; }
    }
}
