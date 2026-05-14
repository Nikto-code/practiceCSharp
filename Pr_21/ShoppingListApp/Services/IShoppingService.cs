using System.Collections.Generic;
using System.Threading.Tasks;
using task1.Models;

namespace task1.Services
{
    public interface IShoppingService
    {
        Task<List<ShoppingItem>> GetAllAsync();
        Task AddAsync(ShoppingItem item);
        Task ToggleBoughtAsync(int id);
        Task DeleteAsync(int id);
    }
}