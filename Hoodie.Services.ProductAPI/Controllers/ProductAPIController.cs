using AutoMapper;
using Hoodie.Services.ProductAPI.Data;
using Hoodie.Services.ProductAPI.Models;
using Hoodie.Services.ProductAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Hoodie.Services.ProductAPI.Controllers
{
    [Route("api/product")]
    [ApiController]
    [Authorize]
    public class ProductAPIController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private ResponseDto _responseDto;
        private IMapper _mapper;

        public ProductAPIController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _responseDto = new ResponseDto();
        }

        [HttpGet]
        public ResponseDto Get() {
            try { 
                IEnumerable<Product> productsList = _dbContext.Products.ToList();
                _responseDto.Result = _mapper.Map<IEnumerable<ProductDto>> (productsList);

            }catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpGet("{id}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Product product = _dbContext.Products.First(x => x.ProductId == id);
                _responseDto.Result = _mapper.Map<ProductDto>(product);

            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Post([FromBody] ProductDto productDto)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDto);
                _dbContext.Add(product);
                _dbContext.SaveChanges();

                _responseDto.Result = _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Put([FromBody] ProductDto productDto) {
            try {
                Product product = _mapper.Map<Product>(productDto);
                _dbContext.Update(product);
                _dbContext.SaveChanges();

                _responseDto.Result = _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                _responseDto.IsSuccess=false;
                _responseDto.Message = ex.Message;
            }
            return _responseDto;
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public ResponseDto Delete(int id)
        {
            try {
                Product product = _dbContext.Products.First(x => x.ProductId == id);
                _dbContext.Products.Remove(product);
                _dbContext.SaveChanges();
            } 
            catch(Exception ex) { 
                _responseDto.IsSuccess = false;
                _responseDto.Message = ex.Message; 
            }

            return _responseDto;
        }
    }
}
