using AutoMapper;
using StockManagement.Application.Features.Categories.Commands.CreateCategory;
using StockManagement.Application.Features.Categories.Queries.GetCategoriesList;
using StockManagement.Application.Features.Products.Commands.CreateProduct;
using StockManagement.Application.Features.Products.Commands.UpdateProduct;
using StockManagement.Application.Features.Products.Queries.GetProductDetails;
using StockManagement.Application.Features.Products.Queries.GetProductsList;
using StockManagement.Application.Features.Categories.Queries.GetCategoriesByCreatedDateDescending;
using StockManagement.Domain.Entities;
using StockManagement.Application.Features.Countries.Queries.GetCountryList;

namespace StockManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductListVm>().ReverseMap();
            CreateMap<Product, ProductDetailsVm>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, CreateProductDto>();

            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Category, CategoryListDescendingOrderedVm>().ReverseMap();

            CreateMap<Country, CountryListVm>();

           
        }
    }
}
