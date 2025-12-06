using FluentValidation;

namespace Application.Features.News.Commands.Update;

public class UpdateSectionValidator : AbstractValidator<UpdateNewsCommand>
{
    public UpdateSectionValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}