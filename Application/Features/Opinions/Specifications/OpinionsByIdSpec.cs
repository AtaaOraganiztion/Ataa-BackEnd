using Ardalis.Specification;

namespace Application.Features.Opinions.Specifications;

public class OpinionsByIdSpec : Specification<Domain.Models.Opinions.Entities.Opinions>
{
    public OpinionsByIdSpec(Ulid id)
    {
        Query.Where(p => p.Id.Equals(id));
    }
}