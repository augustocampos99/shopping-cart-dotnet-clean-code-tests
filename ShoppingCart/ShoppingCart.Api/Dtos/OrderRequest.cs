using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Api.Dtos
{
    public class OrderRequest
    {
        public int CustomerId { get; set; }

        public decimal TotalPrice { get; set; }

        public int Status { get; set; }
    }
}
