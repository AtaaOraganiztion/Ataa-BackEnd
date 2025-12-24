
using Application.Features.ContactForm.Commands.Add;
using Application.Features.ContactForm.Commands.Delete;
using Application.Features.ContactForm.Commands.Update;
using Application.Features.ContactForm.Dtos;
using Application.Features.ContactForm.Queries.GetAll;
using Application.Features.ContactForm.Queries.GetById;
using Domain.Routing.BaseRouter;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using Web.Api.Controllers.BaseController;
using Web.Api.Extensions;

namespace Web.Api.Controllers.ContactForm;

public class ContactFormController : ApiBaseController
{
    [HttpPost(Router.ContactForm.Add)]
    public async Task<IActionResult> AddContactForm([FromQuery]AddContactFormCommand request)
    {
        Result<Ulid> result = await mediator.Send(request);
        return result.ToCreatedActionResult();
    }
    
    [HttpDelete(Router.ContactForm.Delete)]
    public async Task<IActionResult> DeleteContactForm(Ulid id)
    {
        Result<Ulid> result =
            await mediator.Send(new DeleteContactFormCommand(id));
        return result.ToActionResult();
    }
    
    [HttpPut(Router.ContactForm.Update)]
    public async Task<IActionResult> UpdateContactForm(Ulid id, [FromForm] UpdateContactFormDto request)
    {
        Result<Ulid> result = await mediator.Send(new UpdateContactFormCommand(id, request));
        return result.ToActionResult();
    }
    
    [HttpGet(Router.ContactForm.GetAll)]
    public async Task<IActionResult> GetAllContactForm([FromQuery] ContactFormFilter request)
    {
        Result<List<GetContactFormDto>> result = await mediator.Send(new GetContactFormQuery(request));
        return result.ToActionResult();
    }
    [HttpGet(Router.ContactForm.GetById)]
    public async Task<IActionResult> GetContactFormById([FromRoute] Ulid id)
    {
        Result<GetContactFormDto> result = await mediator.Send(new GetContactFormByIdQuery(id));
        return result.ToActionResult();
    }
}