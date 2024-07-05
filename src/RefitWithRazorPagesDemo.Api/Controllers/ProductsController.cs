using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RefitWithRazorPagesDemo.DataAccessLayer.Dtos;
using RefitWithRazorPagesDemo.Domain.Entities;

namespace RefitWithRazorPagesDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {  
            return Ok(ProductStore.ProductList);
        }

        [HttpPost]
        public ActionResult<List<Product>> CreateProduct([FromBody] ProductToUpsertDto product)
        {
            ProductStore.ProductList.Add(new Product { Category = product.Category, Name = product.Name, Price = product.Price, CreatedAt=product.CreatedAt });
            return Ok(ProductStore.ProductList);
        }

        [HttpPut("{id}")]
        public ActionResult<List<Product>> UpdateProduct(int id, [FromBody] ProductToUpsertDto productData)
        {
            var productToUpdate = ProductStore.ProductList.SingleOrDefault(x => x.Id == id);
            if (productToUpdate == null)
                return NotFound($"product Id: {id} not found");

            productToUpdate.Category = productData.Category;
            productToUpdate.Name = productData.Name;
            productToUpdate.Price = productData.Price;
            productToUpdate.CreatedAt = productData.CreatedAt;

            ProductStore.ProductList.Where(x => x.Id == id).Select(x => { x.Name = productData.Name; x.Category = productData.Category; x.Price = productData.Price; return x; });
            return Ok(ProductStore.ProductList);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Product>> DeleteProduct(int id)
        {

            var productToDelete = ProductStore.ProductList.SingleOrDefault(x => x.Id == id);
            if (productToDelete == null)
                return NotFound($"product Id: {id} not found");

            ProductStore.ProductList.Remove(productToDelete);
            return Ok(ProductStore.ProductList);
        }
    }
}
