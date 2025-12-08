using Application.Features.News.Dtos;
using Application.Features.Services.Commands.Add;
using Application.Features.Services.Commands.Delete;
using Application.Features.Services.Commands.Update;
using Application.Features.Services.Dtos;
using Application.Features.Services.Queries.GetAll;
using Application.Features.Statics.Commands.Add;
using Application.Features.Statics.Commands.Delete;
using Application.Features.Statics.Commands.Update;
using Application.Features.Statics.Dtos;
using Application.Features.Statics.Queries.GetAll;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers.ServicesController;

public class StaticsController : ApiBaseController
{
    [HttpPost(Router.StaticsRouter.Add)]
    public async Task<IActionResult> AddStatics(AddStaticsCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        return result.ToCreatedActionResult();
    }
    
    [HttpDelete(Router.StaticsRouter.Delete)]
    public async Task<IActionResult> DeleteStatics(Ulid id)
    {
        Result<Ulid> result =
            await mediator.Send(new DeleteStaticsCommand(id));
        return result.ToActionResult();
    }
    
    [HttpPut(Router.StaticsRouter.Update)]
    public async Task<IActionResult> UpdateStatics(Ulid id, [FromForm] UpdateStaticsDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateStaticsCommand(id, request));
        return result.ToActionResult();
    }
    
    [HttpGet(Router.StaticsRouter.GetAll)]
    public async Task<IActionResult> GetAllStatics([FromQuery] StaticsFilter request)
    {
        Result<List<GetStaticsDto>> result = await mediator.Send(new GetStaticsQuery(request));
        return result.ToActionResult();
    }
}