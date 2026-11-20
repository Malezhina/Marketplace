using Catalog.Application.Queries.CatalogItemQueries;
using Catalog.Application.Responses.CatalogItemResponses;

namespace Catalog.API.Controllers;

public class CatalogItemsController : ApiContoller
{
    [HttpGet]
    [ProducesResponseType(typeof(GetCatalogItemsResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCatalogItemsResult>> GetCatalogItems()
    {
        var result = await Mediator.Send(new GetCatalogItemsQuery());
        return Ok(result);
    }
}
