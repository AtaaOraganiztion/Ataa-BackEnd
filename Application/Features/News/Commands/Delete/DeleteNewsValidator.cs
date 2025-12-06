using FluentValidation;

namespace Application.Features.News.Commands.Delete;

public class DeleteNewsValidator : AbstractValidator<DeleteNewsCommand>
{
    public DeleteNewsValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("NewsId is required.");
    }
}