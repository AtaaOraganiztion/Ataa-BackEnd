using Application.Features.Gallery.Commands.Add;
using Application.Features.Services.Commands.Add;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Application.Mapping.Services;

public class GalleryUrlResolver(IHttpContextAccessor httpContextAccessor) : IValueResolver<Domain.Models.Services.Entities.Gallery,AddGalleryCommand,string>
{
    public string Resolve(Domain.Models.Services.Entities.Gallery source, AddGalleryCommand destination, string destMember, ResolutionContext context)
    {
        if (string.IsNullOrEmpty(source.ImageUrl))
            return null;

        var request = httpContextAccessor.HttpContext.Request;
        return $"{request.Scheme}://{request.Host}{source.ImageUrl}";
    }
}