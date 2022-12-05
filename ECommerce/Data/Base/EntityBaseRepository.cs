using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ECommerce.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IBaseEntity
    {
        private readonly ECommerceDbContext _context;
        private readonly DbSet<T> _Entites;
        public EntityBaseRepository(ECommerceDbContext context)
        {
            _context = context;
            _Entites = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await _Entites.AddAsync(entity);    
            await SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var entityId=await _Entites.FirstOrDefaultAsync(x => x.Id==id);
            if (entityId != null)
            {
                _Entites.Remove(entityId);
                await SaveChanges();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(int id)
        => await _Entites.ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = _Entites.AsQueryable();
            query = include.Aggregate(query, (current, include) => current.Include(include));
            return await query.ToListAsync(); 
        }

        

        public async Task<T> GetByIdAsync(int id)
        => await _Entites.FirstOrDefaultAsync(x=> x.Id == id);

        public async Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = _Entites.AsQueryable();
            query = include.Aggregate(query, (current, include) => current.Include(include));
            return await query.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
          EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State= EntityState.Modified;
            await SaveChanges();
        }

        
    }
}
