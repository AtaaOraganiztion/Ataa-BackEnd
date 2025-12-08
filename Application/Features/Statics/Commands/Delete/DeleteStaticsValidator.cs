using FluentValidation;

namespace Application.Features.Statics.Commands.Delete;

public class DeleteStaticsValidator : AbstractValidator<DeleteStaticsCommand>
{
    public DeleteStaticsValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("StaticsId is required.");
    }
}