using FluentValidation;

namespace Application.Features.Services.Commands.Delete;

public class DeleteServicesValidator : AbstractValidator<DeleteServicesCommand>
{
    public DeleteServicesValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("ServicesId is required.");
    }
}