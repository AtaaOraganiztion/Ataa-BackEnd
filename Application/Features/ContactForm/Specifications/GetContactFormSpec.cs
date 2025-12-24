using Application.Features.News.Dtos;
using Application.Features.Features.Dtos;
using Application.Features.ContactForm.Dtos;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.ContactForm.Specifications;

public class GetContactFormSpec : Specification<Domain.Models.ContactForm.Entities.ContactForm>
{
    public GetContactFormSpec(ContactFormFilter ContactFormFilter)
    {
        if (!string.IsNullOrWhiteSpace(ContactFormFilter.Name))
        {
            Query.Where(x => x.Name.Contains(ContactFormFilter.Name));
        }
        
        if (!string.IsNullOrWhiteSpace(ContactFormFilter.Email))
        {
            Query.Where(x => x.Email.Contains(ContactFormFilter.Email));
        }
        
        if (!string.IsNullOrWhiteSpace(ContactFormFilter.EntityName))
        {
            Query.Where(x => x.EntityName.Contains(ContactFormFilter.EntityName));
        }
        if (!string.IsNullOrWhiteSpace(ContactFormFilter.Phone))
        {
            Query.Where(x => x.Phone.Contains(ContactFormFilter.Phone));
        }
        if (!string.IsNullOrWhiteSpace(ContactFormFilter.Message))
        {
            Query.Where(x => x.Message.Contains(ContactFormFilter.Message));
        }
        if (ContactFormFilter.RequestType.HasValue)
        {
            Query.Where(t=>t.RequestType == ContactFormFilter.RequestType.Value);
        }
  
     
        
    }
}