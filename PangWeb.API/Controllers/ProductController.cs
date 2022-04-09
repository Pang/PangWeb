using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PangWeb.API.Data;
using PangWeb.Shared;

namespace PangWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private DataContext _dataContext;
        public ProductController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("GetProducts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _dataContext.Products
                .Where(x => x.Active)
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet("GetProductCategories")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductCategory))]
        public async Task<IActionResult> GetProductCategories()
        {
            var products = await _dataContext.ProductCategories.ToListAsync();

            return Ok(products);
        }

        [HttpGet("GetProductsByCategory/{categoryId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductCategory))]
        public async Task<IActionResult> GetProductCategories(int categoryId)
        {
            var products = await _dataContext.ProductCategories
                .Where(x => x.Id == categoryId)
                .ToListAsync();

            return Ok(products);
        }
    }
}
