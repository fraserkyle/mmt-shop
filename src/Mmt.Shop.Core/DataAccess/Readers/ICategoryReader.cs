using Mmt.Shop.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mmt.Shop.Core.DataAccess.Readers
{
    public interface ICategoryReader
    {
        Task<IEnumerable<Category>> GetAllAsync();
    }
}
