using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aventude.Demo.eShop.Data;
using Aventude.Demo.eShop.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Aventude.Demo.eShop.Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogItemsController : ControllerBase
    {
        private readonly EShopContext _dbContext;

        public CatalogItemsController(EShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult<CatalogItem>> GetCatalogItemAsync(int id)
        {
            var catalogItem = await _dbContext
                .CatalogItems
                .Include(x=>x.Type)
                .Include(x => x.Brand)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (catalogItem == null)
            {
                return NotFound();
            }

            return catalogItem;
        }

        [HttpPost, Route("Search")]
        public ActionResult<List<CompactCatalogItem>> Search([FromBody] SearchQuery searchQuery)
        {
            var name = new SqlParameter("Name", searchQuery.CatalogItemName);
            var minPrice = new SqlParameter("MinimumPrice", searchQuery.MinPrice);
            var maxPrice = new SqlParameter("MaximumPrice", searchQuery.MaxPrice);

            var results = _dbContext.CompactCatalogItems.FromSqlRaw($"EXEC dbo.sp_SearchProductCatalogItems @Name, @MinimumPrice, @MaximumPrice", name, minPrice, maxPrice).ToList();

            return Ok(results);
        }
    }
}