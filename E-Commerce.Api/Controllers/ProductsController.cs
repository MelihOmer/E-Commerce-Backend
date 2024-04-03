using E_Commerce.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var datas = await _productService.GetProductsWithTypeAndBrandAsync();
            return Ok(datas);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var data = await _productService.GetProductByIdWithTypeAndBrandAsync(id);
            return Ok(data);
        }
    }
}
