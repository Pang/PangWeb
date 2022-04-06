using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PangWeb.API.Data;
using PangWeb.API.Services;
using PangWeb.Shared;

namespace PangWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private DataContext _dataContext;
        private DataSeedService _DataSeedService;
        public BlogController(DataContext dataContext, DataSeedService dataSeedService)
        {
            _dataContext = dataContext;
            _DataSeedService = dataSeedService;
        }

        [Authorize]
        [HttpGet("GetAll")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Blog))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _dataContext.Blogs
                .OrderByDescending(x => x.Date)
                .Where(x => x.Active)
                .ToListAsync();

            return Ok(blogs);
        }

        [HttpGet("GetLatest")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Blog))]
        public async Task<IActionResult> GetLatest()
        {
            var blogs = await _dataContext.Blogs
                .OrderByDescending(x => x.Date)
                .Where(x => x.Active)
                .Take(10)
                .ToListAsync();

            return Ok(blogs);
        }

        [HttpGet("Get/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Blog))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var blog = await _dataContext.Blogs
                .OrderByDescending(x => x.Date)
                .Where(x => x.Active && x.Id == id)
                .FirstOrDefaultAsync();

            if (blog == null) return NotFound();
            return Ok(blog);
        }

    }
}
