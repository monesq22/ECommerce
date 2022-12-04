using ECommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class CategoriseController : Controller
    {
        private readonly ECommerceDbContext _context;
        public CategoriseController(ECommerceDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var Response = await _context.Categories.ToListAsync();
            return View(Response);
        }
    }
}
