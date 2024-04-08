using E_Commerce.Core.Enums;
using E_Commerce.Service.Abstract;
using E_Commerce.Service.Helpers;
using Microsoft.AspNetCore.Mvc;


namespace E_Commerce.Api.Controllers
{
    public class ProductsController :BaseApiController
    {
        readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery]RequestParameters requestParameters)
        {
            var datas = await _productService.GetProductsWithTypeAndBrandAsync(requestParameters:requestParameters,orderByProperties: [x => x.ProductTypeId,x => x.Id],
                orderBy: OrderBy.Descending, filter: [(x=>  x.ProductTypeId ==2 ||x.ProductTypeId==3 )]);

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
