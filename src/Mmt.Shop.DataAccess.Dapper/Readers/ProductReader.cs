using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Mmt.Shop.Core;
using Mmt.Shop.Core.DataAccess.Readers;
using Mmt.Shop.Core.Entities;

namespace Mmt.Shop.DataAccess.Dapper.Readers
{
    public class ProductReader : DapperDataAccessBase, IProductReader
    {
        public ProductReader(IDbConnection connection) : base(connection)
        {
        }

        public async Task<IEnumerable<Product>> GetFeaturedProductsAsync()
        {
            return await ProcedureAsync<Product>(Procedures.CatalogueGetFeaturedProducts);
        }
    }
}
