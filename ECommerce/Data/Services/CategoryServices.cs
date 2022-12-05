using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Data.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ECommerceDbContext _context;
        public CategoryServices(ECommerceDbContext context)
        {
            _context = context;
        }
        public async Task<Category> CategoryGetById(int id)
        {
            var Result = await _context.Categories.FirstOrDefaultAsync(x=>x.Id==id);
            return Result;
        }

        public async Task CreateAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var categoryId = await _context.Categories.FirstOrDefaultAsync(x=>x.Id== id);
            if (categoryId != null)
            {
                _context.Categories.Remove(categoryId);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Category>> GetAllAsycn()
        {
            var Result = await _context.Categories.ToListAsync();
            return Result;
        }

        public async Task UpdateAsync(Category entity)
        {
            var CategryId = await _context.Categories.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (CategryId != null)
            {
                CategryId.Id= entity.Id;
                CategryId.Name= entity.Name;
                CategryId.Description= entity.Description;
                await _context.SaveChangesAsync();
            }
            
        }
    }
}
