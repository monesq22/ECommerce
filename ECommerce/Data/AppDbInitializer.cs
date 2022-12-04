using ECommerce.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder builder)
        {
            using(var applicationservies = builder.ApplicationServices.CreateScope())
            {
                var context = applicationservies.ServiceProvider.GetService<ECommerceDbContext>();
                context.Database.EnsureCreated();
                if (!context.Categories.Any())
                {
                    var categories = new List<Category>()
                    {
                        new Category()
                        {
                            Name= "C1",
                            Description="C1"
                        },
                        new Category()
                        {
                            Name= "C2",
                            Description="C2"
                        },
                        new Category()
                        {
                            Name= "C3",
                            Description="C3"
                        }
                    };
                    context.Categories.AddRange(categories);
                    context.SaveChanges();
                }
                if (!context.Products.Any())
                {
                    var Prodcuts = new List<Product>()
                    {
                        new Product()
                        {
                            Name= "P1",
                            Description="D1",
                            Price=150,
                            ImageURL="https...",
                            ProductColor=ProductColor.Red,
                            CategoryId=1
                        },
                        new Product()
                        {
                            Name= "P2",
                            Description="D2",
                            Price=200,
                            ImageURL="https...",
                            ProductColor=ProductColor.Green,
                            CategoryId=2
                        },
                        new Product()
                        {
                            Name= "P3",
                            Description="D3",
                            Price=300,
                            ImageURL="https...",
                            ProductColor=ProductColor.Yellow,
                            CategoryId=3
                        },
                        new Product()
                        {
                            Name= "P4",
                            Description="D4",
                            Price=400,
                            ImageURL="https...",
                            ProductColor=ProductColor.Blue,
                            CategoryId=4
                        }
                    };
                    context.Products.AddRange(Prodcuts);
                    context.SaveChanges();
                }

            }
        }
    }
}
