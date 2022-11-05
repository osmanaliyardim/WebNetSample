using AutoMapper;
using WebNetSample.Entity.Concrete;
using WebNetSample.Entity.Dtos;

namespace Business.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDetailDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => $"{src.Id}"))
            .ForMember(dest => dest.Name,opt => opt.MapFrom(src => $"{src.Name}"))
            .ForMember(dest => dest.Price,opt => opt.MapFrom(src => $"{src.Price}"))
            .ForMember(dest => dest.ImagePath,opt => opt.MapFrom(src => $"{src.ImagePath}"))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => $"{src.CategoryName}"))
            .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => $"{src.SupplierName}"))
            .ForMember(dest => dest.Suppliers, opt => opt.Ignore())
            .ForMember(dest => dest.Categories, opt => opt.Ignore());

        CreateMap<ProductDetailDto, Product>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => $"{src.Id}"))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}"))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => $"{src.Price}"))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => $"{src.ImagePath}"))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => $"{src.CategoryName}"))
            .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => $"{src.SupplierName}"))
            .ForMember(dest => dest.SupplierId, opt => opt.Ignore())
            .ForMember(dest => dest.CategoryId, opt => opt.Ignore())
            .ForMember(dest => dest.Suppliers, opt => opt.Ignore())
            .ForMember(dest => dest.Categories, opt => opt.Ignore())
            .ForMember(dest => dest.CreationDate, opt => opt.Ignore());

        CreateMap<Category, CategoryDetailDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => $"{src.Id}"))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}"))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => $"{src.ImagePath}"))
            .ForMember(dest => dest.ImageFile, opt => opt.Ignore())
            .ForMember(dest => dest.Products, opt => opt.Ignore());

        CreateMap<CategoryDetailDto, Category>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => $"{src.Id}"))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}"))
            .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => $"{src.ImagePath}"))
            .ForMember(dest => dest.Products, opt => opt.Ignore())
            .ForMember(dest => dest.ImageFile, opt => opt.Ignore())
            .ForMember(dest => dest.CreationDate, opt => opt.Ignore());

        CreateMap<Supplier, SupplierDetailDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => $"{src.Id}"))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}"))
            .ForMember(dest => dest.Products, opt => opt.Ignore());

        CreateMap<SupplierDetailDto, Supplier>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => $"{src.Id}"))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}"))
            .ForMember(dest => dest.Products, opt => opt.Ignore())
            .ForMember(dest => dest.CreationDate, opt => opt.Ignore());
    }
}