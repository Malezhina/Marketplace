using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Application.Responses.CatalogItemResponses;

namespace Catalog.Application.Handlers.CatalogItemHandler;

public class GetCatalogItemsQueryHandler(ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<GetCatalogItemsQuery, GetCatalogItemsResult>
{
    public async Task<GetCatalogItemsResult> Handle(GetCatalogItemsQuery query, CancellationToken cancellationToken)
    {
         var catalogItemsList = await catalogItemRepository.GetAllCatalogItemsAsync(cancellationToken);
        return new GetCatalogItemsResult(catalogItemsList);
    }
}
