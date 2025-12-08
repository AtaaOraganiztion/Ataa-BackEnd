using Application.Features.News.Dtos;
using Application.Features.Features.Dtos;
using Application.Features.Statics.Dtos;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Statics.Specifications;

public class GetStaticsSpec : Specification<Domain.Models.Services.Entities.Statics>
{
    public GetStaticsSpec(StaticsFilter StaticsFilter)
    {
        if (!string.IsNullOrWhiteSpace(StaticsFilter.Title))
        {
            Query.Where(x => x.Title.Contains(StaticsFilter.Title));
        }
        
        if (StaticsFilter.Number.HasValue)
        {
            Query.Where(p => p.Number == StaticsFilter.Number.Value);
        }        
  
     
        
    }
}