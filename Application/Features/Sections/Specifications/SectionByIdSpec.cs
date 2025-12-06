using Ardalis.Specification;

namespace Application.Features.Sections.Specifications;

public class SectionByIdSpec : Specification<Domain.Models.News.Entities.Section>
{
    public SectionByIdSpec(Ulid id)
    {
        Query.Where(p => p.Id.Equals(id));
    }
}