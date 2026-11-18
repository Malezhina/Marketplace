using Catalog.Domain.Repositories;
using Marten;

namespace Catalog.Infrastructure.Repositories;

public class CatalogRepository(IDocumentSession session) : IBrandRepository, ICategoryRepository, ICatalogItemRepository
{
    // IBrandRepository
    public async Task<IEnumerable<Brand>> GetAllBrandsAsync(CancellationToken cancellation)
    {
        return await session.Query<Brand>().ToListAsync(cancellation);
    }

    // ICategoryRepository
    public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellation)
    {
        return await session.Query<Category>().ToListAsync(cancellation);
    }

    // ICatalogItemRepository
    public async Task<IEnumerable<CatalogItem>> GetAllCatalogItemsAsync(CancellationToken cancellation)
    {
        return await session.Query<CatalogItem>().ToListAsync(cancellation);
    }

    public async Task<CatalogItem?> GetCatalogItemAsync(Guid id, CancellationToken cancellation)
    {
        return await session.LoadAsync<CatalogItem>(id, cancellation);
    }

    public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByBrandAsync(string brandTitle, CancellationToken cancellation)
    {
        return await session.Query<CatalogItem>()
        .Where(c => c.Brand != null 
            && !String.IsNullOrEmpty(c.Brand.Title)
            && c.Brand.Title.Contains(brandTitle, StringComparison.OrdinalIgnoreCase))
        .ToListAsync(cancellation);
    }

    public async Task<IEnumerable<CatalogItem>> GetCatalogItemsByTitleAsync(string title, CancellationToken cancellation)
    {
         return await session.Query<CatalogItem>()
        .Where(c => !String.IsNullOrEmpty(c.Title)
            && c.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
        .ToListAsync(cancellation);
    }

    public async Task<CatalogItem> CreateCatalogItemAsync(CatalogItem item, CancellationToken cancellation)
    {
        session.Store(item);
        await session.SaveChangesAsync(cancellation);
        return item;
    }

    public async Task<bool> UpdateCatalogItemAsync(CatalogItem item, CancellationToken cancellation)
    {
        session.Store(item);
        await session.SaveChangesAsync(cancellation);
        return true;
    }

    public async Task<bool> DeleteCatalogItemAsync(Guid id, CancellationToken cancellation)
    {
        session.Delete<CatalogItem>(id);
        await session.SaveChangesAsync(cancellation);
        return true;
    }
}
