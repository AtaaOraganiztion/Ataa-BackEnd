using Application.Features.Services.Commands.Add;
using FluentValidation;

namespace Application.Features.Gallery.Commands.Add;

public class AddGalleryValidator : AbstractValidator<AddGalleryCommand>
{
    public AddGalleryValidator()
    {


    }
}