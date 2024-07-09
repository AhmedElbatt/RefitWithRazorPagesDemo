using System.ComponentModel.DataAnnotations;

namespace RefitWithRazorPagesDemo.DataAccessLayer.Dtos
{
    public class ProductToUpsertDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }= DateTime.Now;
    }
}
