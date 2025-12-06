using Application.Features.Sections.Dtos;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Sections.Specifications;

public class GetSectionSpec : Specification<Domain.Models.News.Entities.Section>
{
    public GetSectionSpec(SectionsDto sectionsFiter)
    {
        if (!string.IsNullOrWhiteSpace(sectionsFiter.Heading))
        {
            Query.Where(x => x.Heading.Contains(sectionsFiter.Heading));
        }
        
        if (sectionsFiter.NewsId is { } newsId && newsId != default)
        {
            Query.Where(x => x.NewsId == newsId);
        }
        
        
        
     
        
    }
}