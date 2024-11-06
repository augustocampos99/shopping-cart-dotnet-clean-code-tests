namespace ShoppingCart.Api.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
