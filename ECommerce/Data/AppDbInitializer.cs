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
            using (var applicationservies = builder.ApplicationServices.CreateScope())
            {
                var context = applicationservies.ServiceProvider.GetService<ECommerceDbContext>();
                context.Database.EnsureCreated();
                if (!context.Categories.Any())
                {
                    var categories = new List<Category>()
                    {
                        new Category()
                        {
                            Name= "OMEGA",
                            Description="C1"
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
                            Name= "AQUA TERRA ",
                            Description="AQUA TERRA 150M\r\nCO‑AXIAL MASTER CHRONOMETER 41 MM",
                            Price=300,
                            ImageURL="https://www.omegawatches.com/media/catalog/product/cache/a5c37fddc1a529a1a44fea55d527b9a116f3738da3a2cc38006fcc613c37c391/o/m/omega-seamaster-aqua-terra-150m-22012412102001-l.png",
                            ProductColor=ProductColor.SILVER,
                            CategoryId=1
                        },
                        new Product()
                        {
                            Name= "DIVER",
                            Description="DIVER 300M\r\nCO‑AXIAL MASTER CHRONOMETER 42 MM",
                            Price=500,
                            ImageURL="https://www.omegawatches.com/media/catalog/product/cache/a5c37fddc1a529a1a44fea55d527b9a116f3738da3a2cc38006fcc613c37c391/o/m/omega-seamaster-diver-300m-21032422001001-l.png",
                            ProductColor=ProductColor.Green,
                            CategoryId=1
                        },
                        new Product()
                        {
                            Name= "PLANET",
                            Description="PLANET OCEAN 6000M\r\nCO‑AXIAL MASTER CHRONOMETER 45.5 MM",
                            Price=300,
                            ImageURL="https://www.omegawatches.com/media/catalog/product/cache/a5c37fddc1a529a1a44fea55d527b9a116f3738da3a2cc38006fcc613c37c391/o/m/omega-seamaster-planet-ocean-6000m-co-axial-master-chronometer-45-5-mm-21530462104001-l.png",
                            ProductColor=ProductColor.Yellow,
                            CategoryId=1
                        },
                        new Product()
                        {
                            Name= "SEAMASTER",
                            Description="SEAMASTER 300\r\nCO‑AXIAL MASTER CHRONOMETER 41 MM",
                            Price=400,
                            ImageURL="https://www.omegawatches.com/media/catalog/product/cache/a5c37fddc1a529a1a44fea55d527b9a116f3738da3a2cc38006fcc613c37c391/o/m/omega-seamaster-seamaster-300-co-axial-master-chronometer-41-mm-23430412101001-l.png",
                            ProductColor=ProductColor.Blue,
                            CategoryId=1
                        }
                    };
                    context.Products.AddRange(Prodcuts);
                    context.SaveChanges();
                }

            }
            

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
