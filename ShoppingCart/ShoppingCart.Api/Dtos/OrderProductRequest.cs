using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Api.Dtos
{
    public class OrderProductRequest
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
