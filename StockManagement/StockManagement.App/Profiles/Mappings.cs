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

            CreateMap<ProductDto, ProductListViewModel>().ReverseMap();
            CreateMap<ProductListVm, ProductListViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, ProductListViewModel>().ReverseMap();
            CreateMap<CreateProductDto, ProductDto>().ReverseMap();
            //CreateMap<ProductDetailsViewModel, UpdateProductCommand>().ReverseMap();
            CreateMap<ProductViewModel, UpdateProductCommand>();
            CreateMap<ProductDetailsVm, ProductDetailsViewModel>();
            CreateMap<ProductDetailsVm, ProductViewModel>()
                .ForMember(dest => dest.CategoryId,
                act => act.MapFrom(src => src.Category.CategoryId));

        }
    }
}
