using FluentValidation;

namespace Application.Features.Opinions.Commands.Update;

public class UpdateOpinionsValidator : AbstractValidator<UpdateOpinionsCommand>
{
    public UpdateOpinionsValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}