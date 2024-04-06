using E_Commerce.Service.Errors;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [Route("error/{code}")]
    [ApiExplorerSettings(IgnoreApi =true)]
    public class ErrorController : BaseApiController
    {
        [HttpGet]
        public IActionResult NotFound(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
