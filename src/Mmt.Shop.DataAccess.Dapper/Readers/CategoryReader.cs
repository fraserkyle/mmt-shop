using Mmt.Shop.Core;
using Mmt.Shop.Core.DataAccess.Readers;
using Mmt.Shop.Core.Entities;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Mmt.Shop.DataAccess.Dapper.Readers
{
    public class CategoryReader : DapperDataAccessBase, ICategoryReader
    {
        public CategoryReader(IDbConnection connection) : base(connection)
        {
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await ProcedureAsync<Category>(Procedures.CatalogueGetCategories);
        }
    }
}
