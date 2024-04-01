using AutoMapper;
using ProductAPI.Data.ValueObjects;
using ProductAPI.Model;

namespace ProductAPI.Properties.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig =  new MapperConfiguration(config => 
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });
            return mappingConfig;
        }
    }
}
