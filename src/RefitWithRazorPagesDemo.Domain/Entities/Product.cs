﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefitWithRazorPagesDemo.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; } = new Random().Next(1, 100);
        public string Name { get; set; } = default!;
        public string Category { get; set; } = default!;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}