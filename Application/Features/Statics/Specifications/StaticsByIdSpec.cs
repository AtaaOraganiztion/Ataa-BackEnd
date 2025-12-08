using Ardalis.Specification;

namespace Application.Features.Statics.Specifications;

public class StaticsByIdSpec : Specification<Domain.Models.Services.Entities.Statics>
{
    public StaticsByIdSpec(Ulid id)
    {
        Query.Where(p => p.Id.Equals(id));
    }
}