using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Shin.Web.Models.Dtos;
using Shin.Web.Services.IServices;
using System;
using System.Collections.Generic;
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
    }
}
