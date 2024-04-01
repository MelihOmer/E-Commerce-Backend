using E_Commerce.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var datas = await _context.Products.ToListAsync();
            return Ok(datas);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var data = await _context.Products.SingleOrDefaultAsync(x => x.Id == id);
            return Ok(data);
        }
    }
}
