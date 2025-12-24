using Application.Features.Services.Commands.Add;
using FluentValidation;

namespace Application.Features.ContactForm.Commands.Add;

public class AddContactFormValidator : AbstractValidator<AddContactFormCommand>
{
    public AddContactFormValidator()
    {


    }
}