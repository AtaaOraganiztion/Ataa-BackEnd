using Application.Features.News.Commands.Add;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Application.Mapping.News;

public class NewsUrlResolver(IHttpContextAccessor httpContextAccessor) : IValueResolver<Domain.Models.News.Entities.News, AddNewsCommand, string>
{
    public string Resolve(Domain.Models.News.Entities.News source, AddNewsCommand destination, string destMember, ResolutionContext context)
    {
        if (string.IsNullOrEmpty(source.ImageUrl))
            return null;

        var request = httpContextAccessor.HttpContext.Request;
        return $"{request.Scheme}://{request.Host}{source.ImageUrl}";
    }
}