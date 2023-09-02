using MediatR;

namespace StockManagement.Application.Features.Categories.Queries.GetCategoriesByCreatedDateDescending
{
    public class GetCategoriesByCreatedDateDescendingQuery: IRequest<List<CategoryListDescendingOrderedVm>>
    {
    }
}
