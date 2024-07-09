using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RefitWithRazorPagesDemo.DataAccessLayer.Dtos;
using RefitWithRazorPagesDemo.Web.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RefitWithRazorPagesDemo.Web.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;

        [BindProperty]
        public ProductToUpsertDto ProductToUpsertDto { get; set; } = new ProductToUpsertDto();

        public string ErrorMessage { get; set; } = string.Empty;

        public bool HasError { get; set; } = false;

        public CreateModel(IProductService productService)
        {
            _productService = productService;
        }

        public void OnGet()
        {

        }

        public async Task OnPost()
        {
            if (ProductToUpsertDto.Price < 10)
                ModelState.AddModelError("Error", "Price should be greater than 10 Euros");

            if (!ModelState.IsValid)
            {
                ErrorMessage = ModelState["Error"]!.Errors[0].ErrorMessage;
                HasError = true;
                return;
            }

            await _productService.CreateProduct(ProductToUpsertDto);
            Response.Redirect("Index");

        }
    }
}
