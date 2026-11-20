using System.Net;

namespace Catalog.API.Controllers;

public class BrandsController : ApiContoller
{
    [HttpGet]
    [ProducesResponseType(typeof(GetBrandsResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<GetBrandsResult>> GetBrands()
    {
        var result = await Mediator.Send(new GetBrandsQuery());
        return Ok(result);
    }
}
