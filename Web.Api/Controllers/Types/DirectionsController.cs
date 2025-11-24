
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers.Types;
[ApiController]
[Route("api/[controller]")] 
public class DirectionsController : ApiBaseController
{
    [HttpGet("{id}")]
    public async Task<IActionResult> DirectionsById()
    {
        return Ok("Directions By Id");
    }
    
    
}