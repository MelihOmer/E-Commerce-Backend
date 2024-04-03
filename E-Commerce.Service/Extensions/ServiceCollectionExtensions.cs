using E_Commerce.Service.Abstract;
using E_Commerce.Service.AutoMapperProfiles;
using E_Commerce.Service.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Service.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService,ProductService>();
            services.AddAutoMapper(typeof(MappingProfiles));
        }
    }
}
