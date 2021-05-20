using CompShop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompShop.Data
{
    public class Seed
    {
        public static async Task SeedData(AppDbContext context)
        {
            if (context.Laptops.Any()) return;

            //Add list of specifications
            var specifications = new List<Specification> 
            {
                new Specification
                {
                    Name = "RAM",
                    Config = new Config
                    {
                        Attribute = "8GB",
                        Price = 45.67f,
                        ConfigType = ConfigType.RAM
                    }
                },
                new Specification
                {
                    Name = "RAM",
                    Config = new Config
                    {
                        Attribute = "16GB",
                        Price = 87.88f,
                        ConfigType = ConfigType.RAM
                    }
                },
                new Specification
                {
                    Name = "HDD",
                    Config = new Config
                    {
                        Attribute = "500GB",
                        Price = 123.34f,
                        ConfigType = ConfigType.HDD
                    }
                },
                new Specification
                {
                    Name = "HDD",
                    Config = new Config
                    {
                        Attribute = "1TB",
                        Price = 200.00f,
                        ConfigType = ConfigType.HDD
                    }
                },
                new Specification
                {
                    Name = "COLOR",
                    Config = new Config
                    {
                        Attribute = "Red",
                        Price = 50.76f,
                        ConfigType = ConfigType.COLOR
                    }
                },
                new Specification
                {
                    Name = "COLOR",
                    Config = new Config
                    {
                        Attribute = "Blue",
                        Price = 34.56f,
                        ConfigType = ConfigType.COLOR
                    }
                }
            };
            await context.Specifications.AddRangeAsync(specifications);
            await context.SaveChangesAsync();

            //All Laptops with all available specifications
            var laptops = new List<Laptop>
            {
                new Laptop
                {
                   Name = "Dell",
                   Price = 349.87f
                },
                new Laptop
                {
                   Name = "Toshiba",
                   Price = 345.67f
                },
                new Laptop
                {
                    Name = "HP",
                    Price = 456.76f
                }
            };

            await context.Laptops.AddRangeAsync(laptops);
            await context.SaveChangesAsync();

        }
    }
}
