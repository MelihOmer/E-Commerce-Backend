using AutoMapper;
using E_Commerce.Core.DbEntities;
using E_Commerce.Infrastructure.UnitOfWork;
using E_Commerce.Service.Abstract;
using E_Commerce.Service.Dtos;

namespace E_Commerce.Service.Concrete
{
    public class ProductService : Service<Product>, IProductService
    {
        readonly IMapper _mapper;
        public ProductService(IUow uow, IMapper mapper) : base(uow)
        {
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ProductResultDto>> GetProductsWithTypeAndBrandAsync()
        {
            var data = await GetAllWithWhereAndIncludesAsync(null, x => x.ProductBrand, x => x.ProductType);
            
           return _mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductResultDto>>(data);
        }
        public async Task<Product> GetProductByIdWithTypeAndBrandAsync(int id)
        {
            return await GetEntityWithWhereAndIncludesAsync(x => x.Id == id, x => x.ProductBrand, x => x.ProductType);
        }
    }
}
