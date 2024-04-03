using AutoMapper;
using E_Commerce.Core.DbEntities;
using E_Commerce.Service.Dtos;
using Microsoft.Extensions.Configuration;

namespace E_Commerce.Service.AutoMapperProfiles.Resolvers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductResultDto, string>
    {
        readonly IConfiguration _configuration;

        public ProductUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductResultDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.ImageUrl))
                return _configuration["ApiUrl"] + source.ImageUrl;
            return null;
        }
    }
}
