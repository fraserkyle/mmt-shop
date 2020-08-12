using Mmt.Shop.Core.Entities;
using System.Collections.Generic;

namespace Mmt.Shop.TestUtil.Mothers
{
    public static class ProductMother
    {
        public static IEnumerable<Product> Featured => new[]
        {
            new Product
            {
                ProductId = 1,
                ProductName = "Featured Product 1",
                ProductSku = "10001",
                ProductDescription = "Featured Product 1",
                ProductPrice = 999.99m
            },
            new Product
            {
                ProductId = 2,
                ProductName = "Featured Product 2",
                ProductSku = "20002",
                ProductDescription = "Featured Product 2",
                ProductPrice = 999.99m
            }
        };

        public static IEnumerable<Product> OfCategory => new[]
        {
            new Product
            {
                ProductId = 1,
                ProductName = "Featured Product 1.1",
                ProductSku = "10001",
                ProductDescription = "Featured Product 1",
                ProductPrice = 999.99m
            },
            new Product
            {
                ProductId = 2,
                ProductName = "Featured Product 1.2",
                ProductSku = "10002",
                ProductDescription = "Featured Product 1.2",
                ProductPrice = 999.99m
            }
        };
    }
}
