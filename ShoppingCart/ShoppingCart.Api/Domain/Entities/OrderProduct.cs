namespace ShoppingCart.Api.Domain.Entities
{
    public class OrderProduct
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
