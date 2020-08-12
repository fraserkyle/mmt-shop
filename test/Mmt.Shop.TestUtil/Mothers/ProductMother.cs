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
                ProductName = "Featured Product 1",
                ProductSku = "10001",
                ProductDescription = "Featured Product 1",
                ProductPrice = 999.99m
            },
            new Product
            {
                ProductName = "Featured Product 2",
                ProductSku = "20002",
                ProductDescription = "Featured Product 2",
                ProductPrice = 999.99m
            }
        };
    }
}
