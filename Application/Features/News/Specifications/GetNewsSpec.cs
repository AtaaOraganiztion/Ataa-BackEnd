using Application.Features.News.Dtos;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.News.Specifications;

public class GetNewsSpec : Specification<Domain.Models.News.Entities.News>
{
    public GetNewsSpec(NewsFilter newsFilter)
    {
        if (!string.IsNullOrWhiteSpace(newsFilter.Title))
        {
            Query.Where(x => x.Title.Contains(newsFilter.Title));
        }
        
        if (!string.IsNullOrWhiteSpace(newsFilter.Category))
        {
            Query.Where(x => x.Category.Contains(newsFilter.Category));
        }
        
        if (!string.IsNullOrWhiteSpace(newsFilter.Qoute))
        {
            Query.Where(x => x.Qoute.Contains(newsFilter.Qoute));
        }
     
        
    }
}