using E_Commerce.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{

    public class ProductTypesController : BaseApiController
    {
        readonly IProductTypeService _productTypeService;

        public ProductTypesController(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _productTypeService.GetAllAsync();
            return Ok(data);
        }
    }
}
