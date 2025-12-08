using Application.Features.News.Dtos;
using Application.Features.Services.Dtos;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Services.Specifications;

public class GetServicesSpec : Specification<Domain.Models.Services.Entities.Services>
{
    public GetServicesSpec(ServicesFilter ServicesFilter)
    {
        if (!string.IsNullOrWhiteSpace(ServicesFilter.Title))
        {
            Query.Where(x => x.Title.Contains(ServicesFilter.Title));
        }
        
        if (!string.IsNullOrWhiteSpace(ServicesFilter.ShortDesc))
        {
            Query.Where(x => x.ShortDesc.Contains(ServicesFilter.ShortDesc));
        }
        
     
        
    }
}