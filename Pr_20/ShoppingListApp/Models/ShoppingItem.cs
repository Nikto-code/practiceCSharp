using System.ComponentModel.DataAnnotations;

namespace task1.Models
{
    public class ShoppingItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название товара")]
        public string Name { get; set; } = string.Empty;

        [Range(1, 100, ErrorMessage = "Количество должно быть от 1 до 100")]
        public int Quantity { get; set; }

        public bool Bought { get; set; }
    }
}