namespace ShoppingCart.Api.Domain.Entities
{
    public class BaseResult<T>
    {
        public bool Success { get; set; }

        public T? Result { get; set; }

        public string? Message { get; set; }
    }
}
