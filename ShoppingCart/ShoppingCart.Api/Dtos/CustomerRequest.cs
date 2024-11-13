using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Api.Dtos
{
    public class CustomerRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
