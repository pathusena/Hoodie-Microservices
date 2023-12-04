using AutoMapper;
using Hoodie.Services.ProductAPI.Models;
using Hoodie.Services.ProductAPI.Models.Dto;

namespace Hoodie.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => { 
                config.CreateMap<ProductDto, Product>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
