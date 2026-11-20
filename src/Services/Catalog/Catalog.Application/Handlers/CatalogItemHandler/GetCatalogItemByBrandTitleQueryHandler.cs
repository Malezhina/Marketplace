using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Application.Responses.CatalogItemResponses;

namespace Catalog.Application.Handlers.CatalogItemHandler;

public class GetCatalogItemByBrandTitleQueryHandler(ICatalogItemRepository catalogItemRepository)
    : IRequestHandler<GetCatalogItemByBrandTitleQuery, GetCatalogItemByBrandTitleResult>
{
    public async Task<GetCatalogItemByBrandTitleResult> Handle(GetCatalogItemByBrandTitleQuery query, CancellationToken cancellationToken)
    {
          // Проверяем Brand
//         var brandExists = command.Brand != null
//             && (await brandRepository.GetAllBrandsAsync())
//             .Any(b => b.Id == command?.Brand?.Id);

//         if (!brandExists)
//         {
//             throw new ArgumentException("Указанный бренд не существует");
//         }

//         // Проверяем Category
//         var categoryExists = command.Category != null
//             && (await categoryRepository.GetAllCategoriesAsync())
//             .Any(c => c.Id == command.Category.Id);

//         if (!categoryExists)
//         {
//             throw new ArgumentException("Указанная категория не существует");
//         }

        var catalogItems = await catalogItemRepository.GetCatalogItemsByBrandAsync(query.BrandTitle, cancellationToken);
        return new GetCatalogItemByBrandTitleResult(catalogItems);
    }
}