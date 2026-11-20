namespace Catalog.API.Controllers;

public class BrandsController : ApiContoller
{
    [HttpGet]
    public async Task<ActionResult<GetBrandsResult>> GetBrands()
    {
        var result = await Mediator.Send(new GetBrandsQuery());
        return Ok(result);
    }
}
