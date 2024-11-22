namespace ShoppingCart.Api.Dtos
{
    public class BaseResponse<T>
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public T? Response { get; set; }

    }
}
