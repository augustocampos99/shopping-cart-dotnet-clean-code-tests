﻿namespace ShoppingCart.Api.Contracts
{
    public class ProductRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
