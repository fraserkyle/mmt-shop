using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mmt.Shop.Core.DataAccess.Readers;
using Mmt.Shop.Core.Entities;

namespace Mmt.Shop.Api.Controllers
{
    [Route("api/v1/categories")]
    [ApiController]
    public class CategoryV1Controller : ControllerBase
    {
        private readonly ILogger<CategoryV1Controller> _logger;
        private readonly ICategoryReader _categoryReader;

        public CategoryV1Controller(ILogger<CategoryV1Controller> logger, ICategoryReader categoryReader)
        {
            _logger = logger;
            _categoryReader = categoryReader;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Category>> GetAll()
        {
            try
            {
                return await _categoryReader.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all categories");
                throw;
            }
        }
    }
}
