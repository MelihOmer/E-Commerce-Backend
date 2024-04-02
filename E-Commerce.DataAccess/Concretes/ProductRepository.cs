using E_Commerce.Core.DbEntities;
using E_Commerce.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Infrastructure.Concretes
{
    public class ProductRepository : IProductRepository
    {
        readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var data =await _context.Products
                .Include(x => x.ProductType)
                .Include(x => x.ProductBrand)
                .FirstOrDefaultAsync(p => p.Id == id);
            return data;
        }
        
        public async Task<IReadOnlyList<Product>> GetProductsAllAsync()
        {
            var datas = await _context.Products
                .Include(x => x.ProductType)
                .Include(x => x.ProductBrand)
                .ToListAsync();
            return datas;
        }
    }
}
