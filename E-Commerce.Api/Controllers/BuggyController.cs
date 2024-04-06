using E_Commerce.Infrastructure;
using E_Commerce.Service.Errors;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{

    public class BuggyController : BaseApiController
    {
        private readonly AppDbContext _context;

        public BuggyController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("not-found")]
        public  IActionResult GetNotFoundRequest()
        {
            var product = _context.Products.FirstOrDefault(x => x.Id ==5);
            if(product == null) 
                return NotFound(new ApiResponse(404));
            return Ok();
        }
        [HttpGet("server-error")]
        public IActionResult GetServerError()
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == 5);

            var result = product.ToString();
            return Ok();
        }
        [HttpGet("badrequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        [HttpGet("badrequest/{id}")]
        public IActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}
