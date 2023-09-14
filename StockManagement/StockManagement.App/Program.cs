using Blazored.LocalStorage;
using StockManagement.App.Contracts;
using StockManagement.App.Services;
using StockManagement.App.Services.Base;
using MudBlazor.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();

builder.Services.AddSingleton(new HttpClient
{
    BaseAddress = new Uri("https://localhost:7017")
});

builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7017"));

builder.Services.AddScoped<ICountryDataService, CountryDataService>();
builder.Services.AddScoped<ICompanyDataService, CompanyDataService>();
builder.Services.AddScoped<ISupplierDataService, SupplierDataService>();
builder.Services.AddScoped<ICategoryDataService, CategoryDataService>();
builder.Services.AddScoped<IProductDataService, ProductDataService>();


builder.Services.AddControllers();
builder.Services.AddAuthentication("Cookies").AddCookie(options =>
{
    //options.Cookie.Name = "Cookies";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});

app.Run();