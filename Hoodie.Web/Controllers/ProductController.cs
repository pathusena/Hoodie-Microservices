using Hoodie.Web.Models;
using Hoodie.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Hoodie.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto>? list = new();
            ResponseDto? response = await _productService.GetAllProductsAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            else {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductDto productDto)
        {
            if (ModelState.IsValid) {
                ResponseDto? responseDto = await _productService.CreateProductAsync(productDto);
                if (responseDto != null && responseDto.IsSuccess)
                {
                    TempData["success"] = "Product created successfully";
                    return RedirectToAction("ProductIndex");
                }
                else {
                    TempData["error"] = responseDto?.Message;
                }
            }
            return View(productDto);
        }

        public async Task<IActionResult> ProductDelete(int productId)
        {
            ResponseDto? response = await _productService.GetProductAsync(productId);
            if (response != null && response.IsSuccess)
            {
                ProductDto? productDto = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(productDto);
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductDto productDto)
        {
            ResponseDto? response = await _productService.DeleteProductAsync(productDto.ProductId);
            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Product deleted successfully";
                return RedirectToAction("ProductIndex");
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return RedirectToAction("ProductIndex");
        }

        public async Task<IActionResult> ProductUpdate(int productId)
        {
            ResponseDto? response = await _productService.GetProductAsync(productId);
            if (response != null && response.IsSuccess)
            {
                ProductDto? productDto = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(productDto);
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _productService.UpdateProductAsync(productDto);
                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Product updated successfully";
                    return RedirectToAction("ProductIndex");
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
            }

            return View(productDto);
        }
    }
}
