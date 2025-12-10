using Application.Features.Gallery.Commands.Add;
using Application.Features.Gallery.Commands.Delete;
using Application.Features.Gallery.Commands.Update;
using Application.Features.Gallery.Dtos;
using Application.Features.Gallery.Queries.GetAll;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Controllers.BaseController;
using Domain.Routing.BaseRouter;
using SharedKernel;
using Web.Api.Extensions;
using Router = Domain.Routing.BaseRouter.Router;

namespace Web.Api.Controllers.ServicesController;

public class GalleryController : ApiBaseController
{
    [HttpPost(Router.GalleryRouter.Add)]
    public async Task<IActionResult> AddGallery([FromForm]AddGalleryCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        return result.ToCreatedActionResult();
    }
    
    [HttpDelete(Router.GalleryRouter.Delete)]
    public async Task<IActionResult> DeleteGallery(Ulid id)
    {
        Result<Ulid> result =
            await mediator.Send(new DeleteGalleryCommand(id));
        return result.ToActionResult();
    }
    
    [HttpPut(Router.GalleryRouter.Update)]
    public async Task<IActionResult> UpdateGallery(Ulid id, [FromForm] UpdateGalleryDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateGalleryCommand(id, request));
        return result.ToActionResult();
    }
    [HttpGet(Router.GalleryRouter.GetAll)]
    public async Task<IActionResult> GetAllGallery([FromQuery] GalleryFilter request)
    {
        Result<List<GetGalleryDto>> result = await mediator.Send(new GetGalleryQuery(request));
        return result.ToActionResult();
    }
    
}