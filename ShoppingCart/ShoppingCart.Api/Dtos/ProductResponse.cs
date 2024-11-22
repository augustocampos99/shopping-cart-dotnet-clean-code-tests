namespace ShoppingCart.Api.Dtos
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }
    }
}
