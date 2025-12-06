using Ardalis.Specification;

namespace Application.Features.News.Specifications;

public class NewsByIdSpec : Specification<Domain.Models.News.Entities.News>
{
    public NewsByIdSpec(Ulid id)
    {
        Query.Where(p => p.Id.Equals(id));
    }
}