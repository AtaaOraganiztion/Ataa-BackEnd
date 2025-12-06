using FluentValidation;

namespace Application.Features.News.Commands.Delete;

public class DeleteSectionValidator : AbstractValidator<DeleteNewsCommand>
{
    public DeleteSectionValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("NewsId is required.");
    }
}