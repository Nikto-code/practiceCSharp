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
         public IActionResult Index()
        {
            var items = _shoppingService.GetAll();
            return View(items);
        }

        public IActionResult Add()
        {
            return View(new ShoppingItemViewModel());
        }

        [HttpPost]
        public IActionResult Add(ShoppingItemViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var item = new ShoppingItem
                {
                    Name = viewModel.Name,
                    Quantity = viewModel.Quantity
                };
                _shoppingService.Add(item);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        public IActionResult Mark(int id)
        {
            _shoppingService.Mark(id);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _shoppingService.Delete(id);
            ViewBag.Message = "Товар удалён";

            return View("Index", _shoppingService.GetAll());
        }
    }
}