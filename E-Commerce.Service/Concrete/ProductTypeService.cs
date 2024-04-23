using E_Commerce.Core.DbEntities;
using E_Commerce.Infrastructure.UnitOfWork;
using E_Commerce.Service.Abstract;

namespace E_Commerce.Service.Concrete
{
    public class ProductTypeService : Service<ProductType>, IProductTypeService
    {
        public ProductTypeService(IUow uow) : base(uow)
        {
        }
    }
}
