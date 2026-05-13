using System.Collections.Generic;
using System.Linq;
using task1.Models;

namespace task1.Services
{
    public class ShoppingService : IShoppingService
    {
        private static List<ShoppingItem> _items = new List<ShoppingItem>
        {
            new ShoppingItem { Id = 1, Name = "Молоко",  Quantity = 2, Bought = false },
            new ShoppingItem { Id = 2, Name = "Хлеб",   Quantity = 1, Bought = false },
            new ShoppingItem { Id = 3, Name = "Яблоки", Quantity = 5, Bought = true  }
        };
        public List<ShoppingItem> GetAll()
        {
            return _items;
        }

        public void Add(ShoppingItem item)
        {
            item.Id = _items.Count > 0 ? _items.Max(i => i.Id) + 1 : 1;
            item.Bought = false;
            _items.Add(item);
        }
        public void Delete(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
                _items.Remove(item);
        }

        public void Mark(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null)
                item.Bought = !item.Bought;
        }
    }
}