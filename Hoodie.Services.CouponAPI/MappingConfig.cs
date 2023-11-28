using AutoMapper;
using Hoodie.Services.CouponAPI.Models;
using Hoodie.Services.CouponAPI.Models.Dto;

namespace Hoodie.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
