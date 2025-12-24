using Ardalis.Specification;

namespace Application.Features.ContactForm.Specifications;

public class ContactFormByIdSpec : Specification<Domain.Models.ContactForm.Entities.ContactForm>
{
    public ContactFormByIdSpec(Ulid id)
    {
        Query.Where(p => p.Id.Equals(id));
    }
}