using FluentValidation;

namespace Application.Features.Gallery.Commands.Delete;

public class DeleteGalleryValidator : AbstractValidator<DeleteGalleryCommand>
{
    public DeleteGalleryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("GalleryId is required.");
    }
}