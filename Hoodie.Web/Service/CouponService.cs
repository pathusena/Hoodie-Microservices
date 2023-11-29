using Hoodie.Web.Models;
using Hoodie.Web.Service.IService;
using Hoodie.Web.Utility;

namespace Hoodie.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public Task<ResponseDto?> CreateCouponAsync(CouponDto couponDto)
        {
            return _baseService.SendAsync(new RequestDto
            {
                ApiType = StaticDetails.ApiTypeEnum.POST,
                Data = couponDto,
                Url = StaticDetails.CouponAPIBase + "/api/coupon/"
            });
        }

        public Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return _baseService.SendAsync(new RequestDto
            {
                ApiType = StaticDetails.ApiTypeEnum.DELETE,
                Url = StaticDetails.CouponAPIBase + "/api/coupon/" + id
            });
        }

        public Task<ResponseDto?> GetAllCouponAsync()
        {
            return _baseService.SendAsync(new RequestDto { 
                ApiType = StaticDetails.ApiTypeEnum.GET,
                Url = StaticDetails.CouponAPIBase + "/api/coupon"
            });
        }

        public Task<ResponseDto?> GetCouponByCodeAsync(string couponCode)
        {
            return _baseService.SendAsync(new RequestDto { 
                ApiType= StaticDetails.ApiTypeEnum.GET,
                Url = StaticDetails.CouponAPIBase + "/api/coupon/GetByCode/" + couponCode
            });
        }

        public Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return _baseService.SendAsync(new RequestDto
            {
                ApiType = StaticDetails.ApiTypeEnum.GET,
                Url = StaticDetails.CouponAPIBase + "/api/coupon/" + id
            });
        }

        public Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return _baseService.SendAsync(new RequestDto
            {
                ApiType = StaticDetails.ApiTypeEnum.PUT,
                Data = couponDto,
                Url = StaticDetails.CouponAPIBase + "/api/coupon/"
            });
        }
    }
}
