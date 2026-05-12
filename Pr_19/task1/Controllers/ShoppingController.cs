using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using task1.Models;

namespace task1.Controllers
{
    public class ShoppingController : Controller
    {
        private static List<ShoppingItem> _items = new List<ShoppingItem>
        {
            new ShoppingItem { Id = 1, Name = "Молоко",  Quantity = 2, Bought = false },
            new ShoppingItem { Id = 2, Name = "Хлеб",   Quantity = 1, Bought = false },
            new ShoppingItem { Id = 3, Name = "Яблоки", Quantity = 5, Bought = true  }
        };

        public IActionResult Index()
        {
            return View(_items);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ShoppingItem item)
        {
            if (ModelState.IsValid)
            {
                item.Id = _items.Count > 0 ? _items.Max(i => i.Id) + 1 : 1;
                item.Bought = false;
                _items.Add(item);
                return RedirectToAction("Index");
            }
            return View(item);
        }
        public IActionResult Mark(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
                item.Bought = !item.Bought;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
                _items.Remove(item);

            return RedirectToAction("Index");
        }
    }
}