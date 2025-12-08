using Ardalis.Specification;

namespace Application.Features.Features.Specifications;

public class FeaturesByIdSpec : Specification<Domain.Models.Services.Entities.Features>
{
    public FeaturesByIdSpec(Ulid id)
    {
        Query.Where(p => p.Id.Equals(id));
    }
}