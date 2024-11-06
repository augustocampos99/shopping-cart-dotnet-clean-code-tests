namespace ShoppingCart.Api.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public int CustomerId { get; set; }

        public decimal TotalPrice { get; set; }

        public int Status { get; set; }

        public Customer Customer { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
