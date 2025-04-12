﻿namespace Product.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string[]? Photos { get; set; }
    }
}
