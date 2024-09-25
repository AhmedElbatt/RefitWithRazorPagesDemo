using RefitWithRazorPagesDemo.Domain.Entities;

namespace RefitWithRazorPagesDemo.Api.Contracts
{
    public interface IProductService
    {
        public List<Product> GetProducts();

        public Product? GetProduct(int id);
    }
}
