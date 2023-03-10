using Shin.Services.ProductApi.Models.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shin.Services.ProductApi.Repository.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<ProductDto>> GetProducts();
    Task<ProductDto> GetProductById(int id);
    Task<ProductDto> CreateUpdateProduct(ProductDto productDto);
    Task<bool> DeleteProduct(int id);
}
