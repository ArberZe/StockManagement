using AutoMapper;
using StockManagement.App.Contracts;
using StockManagement.App.Services;
using StockManagement.App.ViewModels;

namespace StockManagement.App.Profiles
{
    public class Mappings: Profile
    {
        public Mappings()
        {
            CreateMap<CategoryDto, CategoryViewModel>().ReverseMap();
            CreateMap<CategoryListVm, CategoryViewModel>().ReverseMap();
            CreateMap<CreateCategoryCommand, CategoryViewModel>().ReverseMap();
            CreateMap<CreateCategoryDto, CategoryDto>();
            //CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDescendingOrderedViewModel, CategoryListDescendingOrderedVm>().ReverseMap();

            CreateMap<ProductDto, ProductViewModel>().ReverseMap();
            CreateMap<ProductListVm, ProductViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, ProductViewModel>().ReverseMap();
            CreateMap<CreateProductDto, ProductDto>().ReverseMap();
            CreateMap<ProductDetailsViewModel, UpdateProductCommand>().ReverseMap();
            CreateMap<ProductDetailsViewModel, ProductDetailsVm>().ReverseMap();
            CreateMap<ProductDetailsVm, ProductDetailsViewModel>().ForMember(dest => dest.CategoryId,
                act => act.MapFrom(src => src.Category.CategoryId));
        }
    }
}
