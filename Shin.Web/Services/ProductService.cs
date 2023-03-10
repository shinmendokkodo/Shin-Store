using Shin.Web.Models;
using Shin.Web.Models.Dtos;
using Shin.Web.Services.IServices;
using System.Net.Http;
using System.Threading.Tasks;
using static Shin.Web.UrlConfig;

namespace Shin.Web.Services;

public class ProductService : BaseService, IProductService
{
    public ProductService(IHttpClientFactory client) : base(client)
    {

    }

    public async Task<T> CreateProductAsync<T>(ProductDto productDto)
    {
        return await SendAsync<T>(new ApiRequest()
        {
            ApiType = ApiType.POST,
            Data = productDto,
            ApiUrl = ProductApiBase + "api/products",
            AccessToken = string.Empty
        });
    }

    public async Task<T> DeleteProductAsync<T>(int id)
    {
        return await SendAsync<T>(new ApiRequest()
        {
            ApiType = ApiType.DELETE,
            ApiUrl = ProductApiBase + "api/products/" + id,
            AccessToken = string.Empty
        });
    }

    public async Task<T> GetAllProductsAsync<T>()
    {
        return await SendAsync<T>(new ApiRequest()
        {
            ApiType = ApiType.GET,
            ApiUrl = ProductApiBase + "api/products",
            AccessToken = string.Empty
        });
    }

    public async Task<T> GetProductByIdAsync<T>(int id)
    {
        return await SendAsync<T>(new ApiRequest()
        {
            ApiType = ApiType.GET,
            ApiUrl = ProductApiBase + "api/products/" + id,
            AccessToken = string.Empty
        });
    }

    public async Task<T> UpdateProductAsync<T>(ProductDto productDto)
    {
        return await SendAsync<T>(new ApiRequest()
        {
            ApiType = ApiType.PUT,
            Data = productDto,
            ApiUrl = ProductApiBase + "api/products",
            AccessToken = string.Empty
        });
    }
}
