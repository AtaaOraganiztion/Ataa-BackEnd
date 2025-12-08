using Ardalis.Specification;

namespace Application.Features.Services.Specifications;

public class ServicesByIdSpec : Specification<Domain.Models.Services.Entities.Services>
{
    public ServicesByIdSpec(Ulid id)
    {
        Query.Where(p => p.Id.Equals(id));
    }
}