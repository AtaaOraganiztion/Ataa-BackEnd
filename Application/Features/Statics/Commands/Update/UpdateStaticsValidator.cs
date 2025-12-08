using FluentValidation;

namespace Application.Features.Statics.Commands.Update;

public class UpdateStaticsValidator : AbstractValidator<UpdateStaticsCommand>
{
    public UpdateStaticsValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}