namespace Catalog.Application.Handlers.CategoryHandler;

public class GetCategoriesQueryHandler(ICategoryRepository categoryRepository)
    : IRequestHandler<GetCategoriesQuery, GetCategoriesResult>
{
    public async Task<GetCategoriesResult> Handle(GetCategoriesQuery query, CancellationToken cancellationToken)
    {
        var categoriesList = await categoryRepository.GetAllCategoriesAsync(cancellationToken);
        return new GetCategoriesResult(categoriesList);
    }

}
