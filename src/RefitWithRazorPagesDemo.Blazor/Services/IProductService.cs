using Refit;
using RefitWithRazorPagesDemo.DataAccessLayer.Dtos;
using RefitWithRazorPagesDemo.Domain.Entities;

namespace RefitWithRazorPagesDemo.Blazor.Services
{
    public interface IProductService
    {
        [Get("/api/products")]
        Task<List<Product>> GetProducts();

        [Get("/api/products/{id}")]
        Task<Product> GetProductById(int id);

        [Post("/api/products")]
        Task CreateProduct(ProductToUpsertDto product);

        [Put("/api/products/{id}")]
        Task UpdateProduct(int id, ProductToUpsertDto product);

        [Delete("/api/products/{id}")]
        Task DeleteProduct(int id);
    }
}
