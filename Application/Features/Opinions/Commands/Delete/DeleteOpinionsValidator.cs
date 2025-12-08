using FluentValidation;

namespace Application.Features.Opinions.Commands.Delete;

public class DeleteOpinionsValidator : AbstractValidator<DeleteOpinionsCommand>
{
    public DeleteOpinionsValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("OpinionsId is required.");
    }
}