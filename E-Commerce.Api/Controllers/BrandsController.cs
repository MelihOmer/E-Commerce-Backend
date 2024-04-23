using E_Commerce.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{

    public class BrandsController : BaseApiController
    {
        readonly IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _brandService.GetAllAsync();
            return Ok(data);
        }
    }
}
