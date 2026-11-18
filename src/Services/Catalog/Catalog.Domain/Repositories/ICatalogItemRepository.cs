namespace Catalog.Domain.Repositories;

public interface ICatalogItemRepository
{
    Task<CatalogItem> CreateCatalogItemAsync(CatalogItem item, CancellationToken cancellation);
    Task<IEnumerable<CatalogItem>> GetAllCatalogItemsAsync(CancellationToken cancellation);
    Task<CatalogItem?> GetCatalogItemAsync(Guid id, CancellationToken cancellation);
    Task<IEnumerable<CatalogItem>> GetCatalogItemsByTitleAsync(string title, CancellationToken cancellation);
    Task<IEnumerable<CatalogItem>> GetCatalogItemsByBrandAsync(string brandTitle, CancellationToken cancellation);
    Task<bool> UpdateCatalogItemAsync(CatalogItem item, CancellationToken cancellation);
    Task<bool> DeleteCatalogItemAsync(Guid id, CancellationToken cancellation);
}
