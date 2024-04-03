using AutoMapper;
using E_Commerce.Core.DbEntities;
using E_Commerce.Service.AutoMapperProfiles.Resolvers;
using E_Commerce.Service.Dtos;

namespace E_Commerce.Service.AutoMapperProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductResultDto>()
                .ForMember(x => x.ImageUrl, d=>d.MapFrom<ProductUrlResolver>())
                .ReverseMap();
        }
    }
}
