using Mmt.Shop.Core.Entities;
using System.Collections.Generic;

namespace Mmt.Shop.TestUtil.Mothers
{
    public static class CategoryMother
    {
        public static IEnumerable<Category> All => new[]
        {
            new Category
            {
                CategoryId = 1,
                CategoryName = "Category 1"
            },
            new Category
            {
                CategoryId = 2,
                CategoryName = "Category 2"
            }
        };
    }
}
