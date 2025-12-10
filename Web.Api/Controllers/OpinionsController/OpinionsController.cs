
using Application.Features.Opinions.Commands.Add;
using Application.Features.Opinions.Commands.Delete;
using Application.Features.Opinions.Commands.Update;
using Application.Features.Opinions.Dtos;
using Application.Features.Opinions.Queries.GetAll;
using Application.Features.Opinions.Queries.GetById;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers.OpinionsController;

public class OpinionsController : ApiBaseController
{
    [HttpPost(Router.OpinionsRouter.Add)]
    public async Task<IActionResult> AddOpinions(AddOpinionsCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        return result.ToCreatedActionResult();
    }
    
    [HttpDelete(Router.OpinionsRouter.Delete)]
    public async Task<IActionResult> DeleteOpinions(Ulid id)
    {
        Result<Ulid> result =
            await mediator.Send(new DeleteOpinionsCommand(id));
        return result.ToActionResult();
    }
    
    [HttpPut(Router.OpinionsRouter.Update)]
    public async Task<IActionResult> UpdateOpinions(Ulid id, [FromForm] UpdateOpinionsDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateOpinionsCommand(id, request));
        return result.ToActionResult();
    }
    
    [HttpGet(Router.OpinionsRouter.GetAll)]
    public async Task<IActionResult> GetAllOpinions([FromQuery] OpinionsFilter request)
    {
        Result<List<GetOpinionsDto>> result = await mediator.Send(new GetOpinionsQuery(request));
        return result.ToActionResult();
    }
    [HttpGet(Router.OpinionsRouter.GetById)]
    public async Task<IActionResult> GetOpinionsById([FromRoute] Ulid id)
    {
        Result<GetOpinionsDto> result = await mediator.Send(new GetOpinionsByIdQuery(id));
        return result.ToActionResult();
    }
}