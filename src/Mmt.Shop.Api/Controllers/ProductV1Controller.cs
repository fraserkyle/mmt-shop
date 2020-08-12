using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mmt.Shop.Core.DataAccess.Readers;
using Mmt.Shop.Core.Entities;

namespace Mmt.Shop.Api.Controllers
{
    [ApiController]
    [Route("api/v1/products")]
    public class ProductV1Controller : ControllerBase
    {
        private readonly ILogger<ProductV1Controller> _logger;
        private readonly IProductReader _featuredProductReader;

        public ProductV1Controller(ILogger<ProductV1Controller> logger, IProductReader featuredProductReader)
        {
            _logger = logger;
            _featuredProductReader = featuredProductReader;
        }

        [HttpGet]
        [Route("featured")]
        public async Task<IEnumerable<Product>> GetFeaturedAsync()
        {
            try
            {
                return await _featuredProductReader.GetFeaturedProductsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting featured products");
                throw;
            }
        }

        [HttpGet]
        [Route("category/{categoryId}")]
        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            try
            {
                return await _featuredProductReader.GetProductsByCategoryIdAsync(categoryId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting products by category id");
                throw;
            }
        }
    }
}
