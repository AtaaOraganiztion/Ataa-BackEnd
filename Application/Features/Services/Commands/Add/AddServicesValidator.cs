using FluentValidation;

namespace Application.Features.Services.Commands.Add;

public class AddServicesValidator : AbstractValidator<AddServicesCommand>
{
    public AddServicesValidator()
    {
        RuleFor(p => p.MainImage)
            .NotEmpty();
        RuleFor(p => p.ImageFile)
            .NotEmpty();
        RuleFor(p => p.Title)
            .NotEmpty();
        RuleFor(p => p.ShortDesc)
            .NotEmpty();

    }
}