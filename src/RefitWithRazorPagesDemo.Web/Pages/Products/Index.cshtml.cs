using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RefitWithRazorPagesDemo.Domain.Entities;
using RefitWithRazorPagesDemo.Web.Services;

namespace RefitWithRazorPagesDemo.Web.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        public List<Product> Products { get; set; }=new List<Product>();
        public IndexModel(ILogger<IndexModel> logger, IProductService productService)
        {
            _productService = productService;
        }

        public async Task OnGet()
        {
            Products = await _productService.GetProducts();
        }

        public async Task OnPostButtonDelete(int id)
        {
            await _productService.DeleteProduct(id);
            Response.Redirect("/Products/Index");
        }
    }
}
