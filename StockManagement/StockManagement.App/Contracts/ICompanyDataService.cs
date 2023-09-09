﻿using StockManagement.App.Services;
using StockManagement.App.Services.Base;
using StockManagement.App.ViewModels;

namespace StockManagement.App.Contracts
{
    public interface ICompanyDataService
    {
        Task<List<CompanyListViewModel>> GetAllCompanies();
        Task<ApiResponse<CreateCompanyDto>> CreateCompany(CompanyViewModel companyViewModel);
    }
}
