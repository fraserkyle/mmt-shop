using Mmt.Shop.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mmt.Shop.Core.DataAccess.Readers
{
    public interface IFeaturedProductReader
    {
        Task<IEnumerable<Product>> GetFeaturedProducts();
    }
}
