using FluentValidation;

namespace Application.Features.Features.Commands.Update;

public class UpdateGalleryValidator : AbstractValidator<UpdateFeaturesCommand>
{
    public UpdateGalleryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}