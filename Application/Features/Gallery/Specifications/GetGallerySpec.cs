using Application.Features.News.Dtos;
using Application.Features.Features.Dtos;
using Application.Features.Gallery.Dtos;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Gallery.Specifications;

public class GetGallerySpec : Specification<Domain.Models.Services.Entities.Gallery>
{
    public GetGallerySpec(GalleryFilter GalleryFilter)
    {
        if (!string.IsNullOrWhiteSpace(GalleryFilter.ImageUrl))
        {
            Query.Where(x => x.ImageUrl.Contains(GalleryFilter.ImageUrl));
        }
        
           
  
     
        
    }
}