using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using task1.Models;
using task1.Services;

namespace task1.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IShoppingService _shoppingService;

        public ShoppingController(IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _shoppingService.GetAllAsync();
            if (TempData["Message"] != null)
                ViewBag.Message = TempData["Message"];
            return View(items);
        }

        public IActionResult Create()
        {
            return View(new ShoppingItem());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShoppingItem item)
        {
            if (ModelState.IsValid)
            {
                await _shoppingService.AddAsync(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        public async Task<IActionResult> ToggleBought(int id)
        {
            await _shoppingService.ToggleBoughtAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _shoppingService.DeleteAsync(id);
            TempData["Message"] = "Товар удалён";
            return RedirectToAction(nameof(Index));
        }
    }
}