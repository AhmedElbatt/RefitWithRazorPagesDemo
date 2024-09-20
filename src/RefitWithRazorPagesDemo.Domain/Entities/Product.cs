namespace RefitWithRazorPagesDemo.Domain.Entities
{
    public class Product
    {
        public int Id { get;  set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; } = default!;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
