using ECommerce.Data.Static;
using ECommerce.enums;
using ECommerce.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                            Name= "SWATCH",
                            Description="Swatch Group is a diversified multinational holding company"
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
                            Name= "SWATCH ",
                            Description="SWATCH BLUE BOAT SILVER ST. STEEL DARK BLUE DIAL FOR MEN",
                            Price=150,
                            ImageURL="https://waqtee.com/media/catalog/product/y/w/yws420gc.jpg",
                            ProductColor=ProductColor.SILVER,
                            CategoryId=1
                        },
                        new Product()
                        {
                            Name= "P2",
                            Description="D2",
                            Price=200,
                            ImageURL="https://www.tagheuer.com/on/demandware.static/-/Sites-tagheuer-master/default/dwd3773f69/TAG_Heuer_Carrera/CBN2A1F.FC6492/CBN2A1F.FC6492_0913.png?impolicy=resize&width=1920",
                            ProductColor=ProductColor.Green,
                            CategoryId=2
                        },
                        new Product()
                        {
                            Name= "P3",
                            Description="D3",
                            Price=300,
                            ImageURL="https://cdn.shopify.com/s/files/1/0139/3573/8934/products/UTBJ11_Front_6_700x.png?v=1652785822",
                            ProductColor=ProductColor.Yellow,
                            CategoryId=3
                        },
                        new Product()
                        {
                            Name= "P4",
                            Description="D4",
                            Price=400,
                            ImageURL="https://s.yimg.com/aah/movadobaby/breitling-navitimer-rattrapante-limited-edition-men-s-watch-rb0311211q1p2-27.jpg",
                            ProductColor=ProductColor.Blue,
                            CategoryId=3
                        }
                    };
                    context.Products.AddRange(Prodcuts);
                    context.SaveChanges();
                }

            }
            ///

        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder builder)
        {
            using (var applicationservices = builder.ApplicationServices.CreateScope())
            {
                 #region Role
                var roleManager = applicationservices.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                }
                #endregion
                #region User
                var userManager = applicationservices.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                if (await userManager.FindByEmailAsync("admin@admin.com") == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        Email = "admin@admin.com",
                        EmailConfirmed = true,
                        FullName = "Admin User",
                        UserName = "Admin"
                    };
                    await userManager.CreateAsync(newAdminUser, "@Dmin123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);

                    if (await userManager.FindByEmailAsync("user@user.com") == null)
                    {
                        var newOridinalUser = new ApplicationUser()
                        {
                            Email = "user@user.com",
                            EmailConfirmed = true,
                            FullName = "Oridinal User",
                            UserName = "User"
                        };
                        await userManager.CreateAsync(newOridinalUser, "@User123");
                        await userManager.AddToRoleAsync(newOridinalUser, UserRoles.User);
                    }
                    #endregion
                }
            }
        }
    }
}
