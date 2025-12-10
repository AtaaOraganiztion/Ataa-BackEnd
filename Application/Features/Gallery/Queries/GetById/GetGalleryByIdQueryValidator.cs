using FluentValidation;

namespace Application.Features.Gallery.Queries.GetById;

public class GetGalleryByIdQueryValidator : AbstractValidator<GetGalleryByIdQuery>
{
    public GetGalleryByIdQueryValidator()
    {
        RuleFor(x=>x.Id)
            .NotEmpty();
    }
    
}