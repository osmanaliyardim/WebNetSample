using AutoMapper;
using WebNetSample.Entity.Concrete;
using WebNetSample.Entity.Dtos;

namespace Business.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDetailDto>()
                .ForMember(
                    dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.CategoryId)
                ).ReverseMap();

        CreateMap<Category, CategoryDetailDto>().ReverseMap();
        CreateMap<Supplier, SupplierDetailDto>().ReverseMap();
    }
}