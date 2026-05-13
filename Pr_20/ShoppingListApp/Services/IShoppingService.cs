using System.Collections.Generic;
using task1.Models;

namespace task1.Services
{
    public interface IShoppingService
    {
        List<ShoppingItem> GetAll();
        void Add(ShoppingItem item);
        void Delete(int id);
        void Mark(int id);
    }
}