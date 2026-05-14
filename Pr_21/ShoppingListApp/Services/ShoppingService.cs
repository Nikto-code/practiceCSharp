using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using task1.Data;
using task1.Models;

namespace task1.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly AppDbContext _context;

        public ShoppingService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ShoppingItem>> GetAllAsync()
        {
            return await _context.ShoppingItems.ToListAsync();
        }
        public async Task AddAsync(ShoppingItem item)
        {
            _context.ShoppingItems.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task ToggleBoughtAsync(int id)
        {
            var item = await _context.ShoppingItems.FindAsync(id);
            if (item != null)
            {
                item.IsBought = !item.IsBought;
                _context.Update(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.ShoppingItems.FindAsync(id);
            if (item != null)
            {
                _context.ShoppingItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}