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
using StockManagement.Application.Features.Countries.Commands.CreateCountry;
using StockManagement.Application.Features.Suppliers.Queries.GetSupplierList;
using StockManagement.Application.Features.Suppliers.Commands.CreateSupplier;
using StockManagement.Application.Features.Companies.Queries.GetCompanyList;
using StockManagement.Application.Features.Companies.Commands.CreateCompany;

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
            CreateMap<CreateCountryCommand, Country>();
            CreateMap<Country, CreateCountryDto>();

            CreateMap<Supplier, SupplierListVm>();
            CreateMap<CreateSupplierCommand, Supplier>();
            CreateMap<Supplier, CreateSupplierDto>();

            CreateMap<Company, CompanyListVm>();
            CreateMap<CreateCompanyCommand, Company>();
            CreateMap<Company, CreateCompanyDto>();
            CreateMap<Company, CompanyDto>();
           
        }
    }
}
