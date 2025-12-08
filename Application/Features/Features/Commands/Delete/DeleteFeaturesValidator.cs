using FluentValidation;

namespace Application.Features.Features.Commands.Delete;

public class DeleteFeaturesValidator : AbstractValidator<DeleteFeaturesCommand>
{
    public DeleteFeaturesValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("FeaturesId is required.");
    }
}