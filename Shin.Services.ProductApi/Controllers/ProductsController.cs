using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shin.Services.ProductApi.Models.Dtos;
using Shin.Services.ProductApi.Repository;
using Shin.Services.ProductApi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shin.Services.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository productRepository;
    private ResponseDto responseDto;

    public ProductsController(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
        this.responseDto = new ResponseDto();   
    }

    [HttpGet]
    public async Task<ActionResult<ResponseDto>> Get()
    {
        try
        {
            var products = await productRepository.GetProducts();
            responseDto.Result = products;
        }
        catch (Exception ex)
        {
            responseDto.IsSuccess = false;
            responseDto.ErrorMessages = new List<string> { ex.Message };
        }

        return Ok(responseDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResponseDto>> Get(int id)
    {
        try
        {
            var product = await productRepository.GetProductById(id);
            responseDto.Result = product;
        }
        catch (Exception ex)
        {
            responseDto.IsSuccess = false;
            responseDto.ErrorMessages = new List<string> { ex.Message };
        }

        return Ok(responseDto);
    }

    [HttpPost]
    public async Task<ActionResult<ResponseDto>> Post(ProductDto productDto)
    {
        try
        {
            var product = await productRepository.CreateUpdateProduct(productDto);
            responseDto.Result = product;
        }
        catch (Exception ex)
        {
            responseDto.IsSuccess = false;
            responseDto.ErrorMessages = new List<string> { ex.Message };
        }

        return Ok(responseDto);
    }

    [HttpPut]
    public async Task<ActionResult<ResponseDto>> Put(ProductDto productDto)
    {
        try
        {
            var product = await productRepository.CreateUpdateProduct(productDto);
            responseDto.Result = product;
        }
        catch (Exception ex)
        {
            responseDto.IsSuccess = false;
            responseDto.ErrorMessages = new List<string>() { ex.ToString() };
        }
        return Ok(responseDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ResponseDto>> Delete(int id)
    {
        try
        {
            var deleted = await productRepository.DeleteProduct(id);
            responseDto.Result = deleted;
        }
        catch (Exception ex)
        {
            responseDto.IsSuccess = false;
            responseDto.ErrorMessages = new List<string> { ex.ToString() };
        }

        return Ok(responseDto);
    }
}
