using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Drawing;

namespace ECommerce.Data
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
