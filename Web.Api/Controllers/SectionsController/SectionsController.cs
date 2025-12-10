using Application.Features.News.Commands.Add;
using Application.Features.News.Commands.Delete;
using Application.Features.News.Commands.Update;
using Application.Features.News.Dtos;
using Application.Features.News.Queries.GetAll;
using Application.Features.Sections.Commands.Add;
using Application.Features.Sections.Commands.Delete;
using Application.Features.Sections.Commands.Update;
using Application.Features.Sections.Dtos;
using Application.Features.Sections.Queries.GetAll;
using Application.Features.Sections.Queries.GetById;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers.SectionsController;

public class SectionsController : ApiBaseController
{
    [HttpPost(Router.SectionsRouter.Add)]
    public async Task<IActionResult> AddSection(AddSectionCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        return result.ToCreatedActionResult();
    }
    
    [HttpDelete(Router.SectionsRouter.Delete)]
    public async Task<IActionResult> DeleteSection(Ulid id)
    {
        Result<Ulid> result =
            await mediator.Send(new DeleteSectionCommand(id));
        return result.ToActionResult();
    }
    
    [HttpPut(Router.SectionsRouter.Update)]
    public async Task<IActionResult> UpdateSection(Ulid id, [FromBody] SectionsDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateSectionCommand(id, request));
        return result.ToActionResult();
    }
    
    [HttpGet(Router.SectionsRouter.GetAll)]
    public async Task<IActionResult> GetAllSections([FromQuery] SectionsDto request)
    {
        Result<List<GetSectionsDto>> result = await mediator.Send(new GetSectionQuery(request));
        return result.ToActionResult();
    }
    [HttpGet(Router.SectionsRouter.GetById)]
    public async Task<IActionResult> GetSectionsById([FromRoute] Ulid id)
    {
        Result<GetSectionsDto> result = await mediator.Send(new GetSectionsByIdQuery(id));
        return result.ToActionResult();
    }
}