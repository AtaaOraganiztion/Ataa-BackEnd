using Application.Features.News.Dtos;
using Application.Features.Features.Dtos;
using Application.Features.Opinions.Dtos;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Opinions.Specifications;

public class GetOpinionsSpec : Specification<Domain.Models.Opinions.Entities.Opinions>
{
    public GetOpinionsSpec(OpinionsFilter OpinionsFilter)
    {
        if (!string.IsNullOrWhiteSpace(OpinionsFilter.Name))
        {
            Query.Where(x => x.Name.Contains(OpinionsFilter.Name));
        }
        
        if (!string.IsNullOrWhiteSpace(OpinionsFilter.Role))
        {
            Query.Where(x => x.Role.Contains(OpinionsFilter.Role));
        }
        
        if (OpinionsFilter.Rating.HasValue)
        {
            Query.Where(p => p.Rating == OpinionsFilter.Rating.Value);
        }        
  
     
        
    }
}