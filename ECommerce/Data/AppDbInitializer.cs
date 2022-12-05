using ECommerce.enums;
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
                            ImageURL="https://www.tagheuer.com/on/demandware.static/-/Sites-tagheuer-master/default/dw2c45e549/TAG_Heuer_Carrera/CBG2A11.BA0654/CBG2A11.BA0654_0913.png?impolicy=resize&width=1920",
                            ProductColor=ProductColor.Red,
                            CategoryId=5
                        },
                        new Product()
                        {
                            Name= "P2",
                            Description="D2",
                            Price=200,
                            ImageURL="https://www.tagheuer.com/on/demandware.static/-/Sites-tagheuer-master/default/dwd3773f69/TAG_Heuer_Carrera/CBN2A1F.FC6492/CBN2A1F.FC6492_0913.png?impolicy=resize&width=1920",
                            ProductColor=ProductColor.Green,
                            CategoryId=6
                        },
                        new Product()
                        {
                            Name= "P3",
                            Description="D3",
                            Price=300,
                            ImageURL="https://cdn.shopify.com/s/files/1/0139/3573/8934/products/UTBJ11_Front_6_700x.png?v=1652785822",
                            ProductColor=ProductColor.Yellow,
                            CategoryId=7
                        },
                        new Product()
                        {
                            Name= "P4",
                            Description="D4",
                            Price=400,
                            ImageURL="https://s.yimg.com/aah/movadobaby/breitling-navitimer-rattrapante-limited-edition-men-s-watch-rb0311211q1p2-27.jpg",
                            ProductColor=ProductColor.Blue,
                            CategoryId=7
                        }
                    };
                    context.Products.AddRange(Prodcuts);
                    context.SaveChanges();
                }

            }
        }
    }
}
