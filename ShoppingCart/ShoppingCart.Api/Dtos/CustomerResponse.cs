﻿namespace ShoppingCart.Api.Dtos
{
    public class CustomerResponse
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
