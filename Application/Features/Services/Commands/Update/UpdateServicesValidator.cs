using FluentValidation;

namespace Application.Features.Services.Commands.Update;

public class UpdateServicesValidator : AbstractValidator<UpdateServicesCommand>
{
    public UpdateServicesValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}