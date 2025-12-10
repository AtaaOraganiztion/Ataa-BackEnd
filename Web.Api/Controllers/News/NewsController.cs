using Application.Features.News.Commands.Add;
using Application.Features.News.Commands.Delete;
using Application.Features.News.Commands.Update;
using Application.Features.News.Dtos;
using Application.Features.News.Queries.GetAll;
using Application.Features.News.Queries.GetById;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Controllers.BaseController;
using Domain.Routing.BaseRouter;
using SharedKernel;
using Web.Api.Extensions;
using Router = Domain.Routing.BaseRouter.Router;

namespace Web.Api.Controllers.News;

public class NewsController : ApiBaseController
{
    [HttpPost(Router.NewsRouter.Add)]
    public async Task<IActionResult> AddNews([FromForm]AddNewsCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        return result.ToCreatedActionResult();
    }
    
    [HttpDelete(Router.NewsRouter.Delete)]
    public async Task<IActionResult> DeleteNews(Ulid id)
    {
        Result<Ulid> result =
            await mediator.Send(new DeleteNewsCommand(id));
        return result.ToActionResult();
    }
    
    [HttpPut(Router.NewsRouter.Update)]
    public async Task<IActionResult> UpdateNews(Ulid id, [FromForm] UpdateNewsDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateNewsCommand(id, request));
        return result.ToActionResult();
    }
    
    [HttpGet(Router.NewsRouter.GetAll)]
    public async Task<IActionResult> GetAllNews([FromQuery] NewsFilter request)
    {
        Result<List<GetNewsDto>> result = await mediator.Send(new GetNewsQuery(request));
        return result.ToActionResult();
    }
    [HttpGet(Router.NewsRouter.GetById)]
    public async Task<IActionResult> GetNewsById([FromRoute] Ulid id)
    {
        Result<GetNewsDto> result = await mediator.Send(new GetNewsByIdQuery(id));
        return result.ToActionResult();
    }
    
}