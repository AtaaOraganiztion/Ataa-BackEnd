using FluentValidation;

namespace Application.Features.News.Commands.Update;

public class UpdateNewsValidator : AbstractValidator<UpdateNewsCommand>
{
    public UpdateNewsValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}