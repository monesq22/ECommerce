using ECommerce.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Data.Base
{
    public interface IEntityBaseRepository <T> where T : class, IBaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsyc(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
