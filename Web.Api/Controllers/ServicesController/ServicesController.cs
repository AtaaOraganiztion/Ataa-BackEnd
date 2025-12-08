using Application.Features.News.Dtos;
using Application.Features.Services.Commands.Add;
using Application.Features.Services.Commands.Delete;
using Application.Features.Services.Commands.Update;
using Application.Features.Services.Dtos;
using Application.Features.Services.Queries.GetAll;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers.ServicesController;

public class ServicesController() : ApiBaseController
{
    [HttpPost(Router.ServicesRouter.Add)]
    public async Task<IActionResult> AddServices([FromForm]AddServicesCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        return result.ToCreatedActionResult();
    }
    
    [HttpDelete(Router.ServicesRouter.Delete)]
    public async Task<IActionResult> DeleteServices(Ulid id)
    {
        Result<Ulid> result =
            await mediator.Send(new DeleteServicesCommand(id));
        return result.ToActionResult();
    }
    
    [HttpPut(Router.ServicesRouter.Update)]
    public async Task<IActionResult> UpdateServices(Ulid id, [FromForm] UpdateServicesDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateServicesCommand(id, request));
        return result.ToActionResult();
    }
    
    [HttpGet(Router.ServicesRouter.GetAll)]
    public async Task<IActionResult> GetAllServices([FromQuery] ServicesFilter request)
    {
        Result<List<GetServicesDto>> result = await mediator.Send(new GetServicesQuery(request));
        return result.ToActionResult();
    }
    
}