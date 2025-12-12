using FluentValidation;

namespace Application.Features.Gallery.Commands.Update;

public class UpdateGalleryValidator : AbstractValidator<UpdateGalleryCommand>
{
    public UpdateGalleryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}