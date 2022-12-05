using ECommerce.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Data.Services
{
    public interface ICategoryServices
    {
        Task<IEnumerable<Category>> GetAllAsycn();
        Task<Category> CategoryGetById(int id);
        Task CreateAsync(Category entity);
        Task UpdateAsync(Category entity);
        Task DeleteAsync(int id);
    }
}
