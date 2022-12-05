using ECommerce.Data;
using ECommerce.Data.Services;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class categoriesController : Controller
    {
        private readonly ICategoryServices _services ;
        public categoriesController(ICategoryServices services)
        {
            _services = services;
        }
        public async Task<IActionResult> Index()
        {
            var Response = await _services.GetAllAsycn();
            return View(Response);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name , Description")]Category category)
        {
            if (ModelState.IsValid)
            {
                await _services.CreateAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var Category = await _services.CategoryGetById(id);
            if (Category!=null)
            {
                return View(Category);
            }
            return View("NotFound");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var Category = await _services.CategoryGetById(id);
            if (Category != null)
            {
                return View(Category);
            }
            return View("NotFound");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            var categoryId = await _services.CategoryGetById(category.Id);
            if (!ModelState.IsValid && categoryId == null)
            {
                return View("NotFound");

            }
            await _services.UpdateAsync(category);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _services.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
