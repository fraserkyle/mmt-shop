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
    [Route("v1/products")]
    public class ProductV1Controller : ControllerBase
    {
        private readonly ILogger<ProductV1Controller> _logger;
        private readonly IFeaturedProductReader _featuredProductReader;

        public ProductV1Controller(ILogger<ProductV1Controller> logger, IFeaturedProductReader featuredProductReader)
        {
            _logger = logger;
            _featuredProductReader = featuredProductReader;
        }

        [HttpGet]
        [Route("featured")]
        public async Task<IEnumerable<Product>> GetFeatured()
        {
            try
            {
                return await _featuredProductReader.GetFeaturedProducts();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting featured products");
                throw;
            }
        }
    }
}
