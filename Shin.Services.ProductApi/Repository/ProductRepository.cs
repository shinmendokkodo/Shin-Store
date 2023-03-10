using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shin.Services.ProductApi.DbContexts;
using Shin.Services.ProductApi.Models;
using Shin.Services.ProductApi.Models.Dtos;
using Shin.Services.ProductApi.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shin.Services.ProductApi.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext dbContext;
    private readonly IMapper mapper;

    public ProductRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
    {
        var product = mapper.Map<Product>(productDto);
        if (product.Id > 0)
        {
            dbContext.Products.Update(product);
        }
        else
        {
            await dbContext.Products.AddAsync(product);
        }        
        await dbContext.SaveChangesAsync();
        return mapper.Map<ProductDto>(product);
    }

    public async Task<bool> DeleteProduct(int id)
    {
        try
        {
            var product = await dbContext.Products.FindAsync(id);
            if (product != null)
            {
                dbContext.Products.Remove(product);
                await dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
        catch
        {
            return false;
        }
    }

    public async Task<ProductDto> GetProductById(int id)
    {
        var product = await dbContext.Products.FindAsync(id);
        return mapper.Map<ProductDto>(product);
    }

    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        var products = await dbContext.Products.ToListAsync();
        return mapper.Map<List<ProductDto>>(products);
    }
}
