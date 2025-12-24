using FluentValidation;

namespace Application.Features.ContactForm.Commands.Update;

public class UpdateContactFormValidator : AbstractValidator<UpdateContactFormCommand>
{
    public UpdateContactFormValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}