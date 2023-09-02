using MediatR;

namespace StockManagement.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery: IRequest<List<CategoryListVm>>
    {
    }
}
