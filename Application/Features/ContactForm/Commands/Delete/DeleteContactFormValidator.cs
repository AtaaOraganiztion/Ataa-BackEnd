using FluentValidation;

namespace Application.Features.ContactForm.Commands.Delete;

public class DeleteContactFormValidator : AbstractValidator<DeleteContactFormCommand>
{
    public DeleteContactFormValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("ContactFormId is required.");
    }
}