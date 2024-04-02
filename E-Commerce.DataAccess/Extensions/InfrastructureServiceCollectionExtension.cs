using E_Commerce.Core.Abstracts;
using E_Commerce.Core.Interfaces;
using E_Commerce.Infrastructure.Concretes;
using E_Commerce.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Infrastructure.Extensions
{
    public static class InfrastructureServiceCollectionExtension
    {
        public static void AddDataAccess(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("default"));
            });
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            services.AddScoped<IUow, Uow>();
        }
    }
}
