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
                Id = 1,
                Category = "Mobile",
                Name = "IPHONE 11",
                Price = 1500
            });

            ProductList.Add(new Product
            {
                Id = 2,
                Category = "Laptop",
                Name = "Dell MX9900",
                Price = 1500,
            });

            ProductList.Add(new Product
            {

                Id = 3,
                Category = "TV",
                Name = "Samsung TV",
                Price = 1500,
            });
        }
    }
}
