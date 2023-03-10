using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shin.Web.Models.Dtos;
using Shin.Web.Services;
using Shin.Web.Services.IServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Shin.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto> products = new();
            var response = await productService.GetAllProductsAsync<ResponseDto>();
            if (response != null && response.IsSuccess) 
            {
                products = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            return View(products);
        }

		public IActionResult ProductCreate()
		{
			return View();
		}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var response = await productService.CreateProductAsync<ResponseDto>(productDto);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(productDto);
        }

        public async Task<IActionResult> ProductEdit(int productId)
        {            
            var response = await productService.GetProductByIdAsync<ResponseDto>(productId);
            if (response != null && response.IsSuccess)
            {
                ProductDto product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                var response = await productService.UpdateProductAsync<ResponseDto>(product);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(product);
        }

        public async Task<IActionResult> ProductDelete(int productId)
        {
            var response = await productService.GetProductByIdAsync<ResponseDto>(productId);
            if (response != null && response.IsSuccess)
            {
                ProductDto product = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                return View(product);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductDelete(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                var response = await productService.DeleteProductAsync<ResponseDto>(product.Id);
                if (response.IsSuccess)
                {
                    return RedirectToAction(nameof(ProductIndex));
                }
            }
            return View(product);
        }
    }
}
