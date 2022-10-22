using AutoMapper;
using Entity.Concrete;
using WebNetSample.Entity.Dtos;

namespace Business.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDetails, ProductDetailDto>();
        CreateMap<ProductDetailDto, ProductDetails>(); //vice versa
    }
}