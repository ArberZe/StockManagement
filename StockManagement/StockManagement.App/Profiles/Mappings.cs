using AutoMapper;
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
            CreateMap<CreateCategoryDto, CategoryDto>().ReverseMap();
        }
    }
}
