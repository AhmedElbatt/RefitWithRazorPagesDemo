using Microsoft.AspNetCore.Mvc;
using RefitWithRazorPagesDemo.Api.Contracts;
using RefitWithRazorPagesDemo.DataAccessLayer.Dtos;
using RefitWithRazorPagesDemo.Domain.Entities;

namespace RefitWithRazorPagesDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            //return Ok(ProductStore.ProductList);

            return Ok(_productService.GetProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = ProductStore.ProductList.SingleOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound($"product Id: {id} not found");

            return Ok(product);
        }

        [HttpPost]
        public ActionResult<List<Product>> CreateProduct([FromBody] ProductToUpsertDto product)
        {
            ProductStore.ProductList.Add(new Product { Id = new Random().Next(4, 100), Category = product.Category, Name = product.Name, Price = product.Price, CreatedAt = product.CreatedAt });

            return Created();
        }

        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct(int id, [FromBody] ProductToUpsertDto productData)
        {
            var productToUpdate = ProductStore.ProductList.SingleOrDefault(x => x.Id == id);
            if (productToUpdate == null)
                return NotFound($"product Id: {id} not found");

            productToUpdate.Category = productData.Category;
            productToUpdate.Name = productData.Name;
            productToUpdate.Price = productData.Price;
            productToUpdate.CreatedAt = productData.CreatedAt;

            ProductStore.ProductList.Where(x => x.Id == id).Select(x => { x.Name = productData.Name; x.Category = productData.Category; x.Price = productData.Price; return x; });
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {

            var productToDelete = ProductStore.ProductList.SingleOrDefault(x => x.Id == id);
            if (productToDelete == null)
                return NotFound($"product Id: {id} not found");

            ProductStore.ProductList.Remove(productToDelete);
            return Ok(ProductStore.ProductList);
        }
    }
}
