using AutoMapper;
using Shin.Services.ProductApi.Models;
using Shin.Services.ProductApi.Models.Dtos;

namespace Shin.Services.ProductApi;

public class MapperConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<ProductDto, Product>().ReverseMap();
        });

        return mappingConfig;
    }
}
