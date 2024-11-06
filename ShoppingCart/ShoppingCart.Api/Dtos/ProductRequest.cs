using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Api.Dtos
{
    public class ProductRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
