using System.ComponentModel.DataAnnotations;

namespace task1.Models
{
    public class ShoppingItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название товара")]
        [StringLength(100, ErrorMessage = "Не более 100 символов")]
        public string Name { get; set; } = string.Empty;

        [Range(1, 100, ErrorMessage = "Количество от 1 до 100")]
        public int Quantity { get; set; }

        public bool IsBought { get; set; }
    }
}