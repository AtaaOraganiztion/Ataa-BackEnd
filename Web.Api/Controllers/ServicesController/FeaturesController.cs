using Application.Features.News.Dtos;
using Application.Features.Features.Commands.Add;
using Application.Features.Features.Commands.Delete;
using Application.Features.Features.Commands.Update;
using Application.Features.Features.Dtos;
using Application.Features.Features.Queries.GetAll;
using Application.Features.Services.Commands.Add;
using Application.Features.Services.Dtos;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers.FeaturesController;

public class FeaturesController : ApiBaseController
{
    [HttpPost(Router.FeaturesRouter.Add)]
    public async Task<IActionResult> AddFeatures(AddFeaturesCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        return result.ToCreatedActionResult();
    }
    
    [HttpDelete(Router.FeaturesRouter.Delete)]
    public async Task<IActionResult> DeleteFeatures(Ulid id)
    {
        Result<Ulid> result =
            await mediator.Send(new DeleteFeaturesCommand(id));
        return result.ToActionResult();
    }
    
    [HttpPut(Router.FeaturesRouter.Update)]
    public async Task<IActionResult> UpdateFeatures(Ulid id, [FromForm] UpdateFeaturesDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateFeaturesCommand(id, request));
        return result.ToActionResult();
    }
    
    [HttpGet(Router.FeaturesRouter.GetAll)]
    public async Task<IActionResult> GetAllFeatures([FromQuery] FeaturesFilter request)
    {
        Result<List<GetFeaturesDto>> result = await mediator.Send(new GetFeaturesQuery(request));
        return result.ToActionResult();
    }
}