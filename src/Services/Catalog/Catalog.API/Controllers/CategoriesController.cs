namespace Catalog.API.Controllers;

public class CategoriesController : ApiContoller
{
    [HttpGet]
    [ProducesResponseType(typeof(GetCategoriesResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetCategoriesResult>> GetCategories()
    {
        var result = await Mediator.Send(new GetCategoriesQuery());
        return Ok(result);
    }
}
