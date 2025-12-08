using Application.Features.News.Dtos;
using Application.Features.Features.Dtos;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Features.Specifications;

public class GetFeaturesSpec : Specification<Domain.Models.Services.Entities.Features>
{
    public GetFeaturesSpec(FeaturesFilter FeaturesFilter)
    {
        if (!string.IsNullOrWhiteSpace(FeaturesFilter.Title))
        {
            Query.Where(x => x.Title.Contains(FeaturesFilter.Title));
        }
        
        if (!string.IsNullOrWhiteSpace(FeaturesFilter.Desc))
        {
            Query.Where(x => x.Desc.Contains(FeaturesFilter.Desc));
        }
        
        if (!string.IsNullOrWhiteSpace(FeaturesFilter.Benifit))
        {
            Query.Where(x => x.Benifit.Contains(FeaturesFilter.Benifit));
        }
     
        
    }
}