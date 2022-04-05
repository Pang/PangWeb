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

        [HttpGet("GetAll")]
        public async Task<List<Blog>> GetAll()
        {
            return await _dataContext.Blogs
                .OrderByDescending(x => x.Date)
                .Where(x => x.active)
                .ToListAsync();
        }

    }
}
