using E_Commerce.Core.DbEntities;
using E_Commerce.Infrastructure.UnitOfWork;
using E_Commerce.Service.Abstract;

namespace E_Commerce.Service.Concrete
{
    public class BrandService : Service<ProductBrand>, IBrandService
    {
        public BrandService(IUow uow) : base(uow)
        {
        }
    }
}
