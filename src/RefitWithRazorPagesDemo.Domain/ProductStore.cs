using RefitWithRazorPagesDemo.Domain.Entities;

namespace RefitWithRazorPagesDemo.Api
{
    public static class ProductStore
    {
        public static List<Product> ProductList = new List<Product>();

        static ProductStore()
        {
            ProductList.Add(new Product
            {
                Category = "Mobile",
                Name = "IPHONE 11",
                Price = 1500
            }); 

            ProductList.Add(new Product
            {
                Category = "laptop",
                Name = "Dell MX9900",
                Price = 1500,
            });

            ProductList.Add(new Product
            {
                Category = "smart watches",
                Name = "mac fit",
                Price = 1500,
            });
        }
    }
}
