using FluentValidation;

namespace Application.Features.Features.Commands.Update;

public class UpdateFeaturesValidator : AbstractValidator<UpdateFeaturesCommand>
{
    public UpdateFeaturesValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}