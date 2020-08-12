using Mmt.Shop.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mmt.Shop.Core.DataAccess.Readers
{
    public interface IProductReader
    {
        Task<IEnumerable<Product>> GetFeaturedProductsAsync();

        Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId);
    }
}
