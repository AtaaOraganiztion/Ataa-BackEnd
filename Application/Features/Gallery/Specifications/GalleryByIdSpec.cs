using Ardalis.Specification;

namespace Application.Features.Gallery.Specifications;

public class GalleryByIdSpec : Specification<Domain.Models.Services.Entities.Gallery>
{
    public GalleryByIdSpec(Ulid id)
    {
        Query.Where(p => p.Id.Equals(id));
    }
}