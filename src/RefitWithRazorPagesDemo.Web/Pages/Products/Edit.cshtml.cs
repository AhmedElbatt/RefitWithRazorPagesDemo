using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RefitWithRazorPagesDemo.DataAccessLayer.Dtos;
using RefitWithRazorPagesDemo.Domain.Entities;
using RefitWithRazorPagesDemo.Web.Services;
using System.Runtime.CompilerServices;

namespace RefitWithRazorPagesDemo.Web.Pages.Products
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public ProductToUpsertDto ProductToUpdate { get; set; } = new ProductToUpsertDto();
        public string ErrorMessage { get; set; } = string.Empty;
        public bool HasError { get; set; } = false;

        private readonly IProductService _productService;

        public EditModel(IProductService productService)
        {
            _productService = productService;
        }

        public async Task OnGet(int? productId)
        {
            if (productId == null)
                Response.Redirect("Index");

            var product = await _productService.GetProductById(productId!.Value);

            if (product == null)
                Response.Redirect("Index");

            ProductToUpdate.Name = product.Name;
            ProductToUpdate.Category = product.Category;
            ProductToUpdate.Price = product.Price;
            ProductToUpdate.CreatedAt = product.CreatedAt;
        }

        public async Task OnPost(int? productId)
        {

            if (productId == null)
                Response.Redirect("Index");

            if (ProductToUpdate.Price < 10)
                ModelState.AddModelError("Error", "Price should be greater than 10 Euros");

            if (!ModelState.IsValid)
            {
                ErrorMessage = ModelState["Error"]!.Errors[0].ErrorMessage;
                HasError = true;
            }
            else
            {
                await _productService.UpdateProduct(productId.Value, ProductToUpdate);
                Response.Redirect("Index");
            }
        }
    }
}
