using Hoodie.Services.ProductAPI.Models.Dto;
using Hoodie.Web.Models;
using Hoodie.Web.Service.IService;
using Hoodie.Web.Utility;

namespace Hoodie.Web.Service
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;

        public async Task<ResponseDto?> CreateProductAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = StaticDetails.ApiTypeEnum.POST,
                Data = productDto,
                Url = StaticDetails.ProductAPIBase + "/api/product"
            });
        }

        public async Task<ResponseDto?> DeleteProductAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = StaticDetails.ApiTypeEnum.DELETE,
                Url = StaticDetails.ProductAPIBase + "/api/product" + id,
            });
        }

        public async Task<ResponseDto?> GetAllProductsAsync()
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = StaticDetails.ApiTypeEnum.GET,
                Url = StaticDetails.ProductAPIBase + "/api/product"
            });
        }

        public async Task<ResponseDto?> GetProductAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = StaticDetails.ApiTypeEnum.GET,
                Url = StaticDetails.ProductAPIBase + "/api/product" + id,
            });
        }

        public async Task<ResponseDto?> UpdateProductAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = StaticDetails.ApiTypeEnum.PUT,
                Data = productDto,
                Url = StaticDetails.ProductAPIBase + "/api/product"
            });
        }
    }
}
