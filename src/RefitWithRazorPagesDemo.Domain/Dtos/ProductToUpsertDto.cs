﻿namespace RefitWithRazorPagesDemo.DataAccessLayer.Dtos
{
    public class ProductToUpsertDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
