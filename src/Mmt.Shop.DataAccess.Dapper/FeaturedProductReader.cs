using System.Collections.Generic;
using System.Threading.Tasks;
using Mmt.Shop.Core.DataAccess.Readers;
using Mmt.Shop.Core.Entities;

namespace Mmt.Shop.DataAccess.Dapper
{
    public class FeaturedProductReader : DapperDataAccessBase, IFeaturedProductReader
    {
        public async Task<IEnumerable<Product>> GetFeaturedProducts()
        {
            return await ProcedureAsync<Product>("Catalogue.spGetFeaturedProducts");
        }
    }
}
