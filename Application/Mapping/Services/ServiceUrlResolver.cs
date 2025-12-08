using Application.Features.Services.Commands.Add;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Application.Mapping.Services;

public class ServiceUrlResolver(IHttpContextAccessor httpContextAccessor) : IValueResolver<Domain.Models.Services.Entities.Services,AddServicesCommand,string>
{
    public string Resolve(Domain.Models.Services.Entities.Services source, AddServicesCommand destination, string destMember, ResolutionContext context)
    {
        if (string.IsNullOrEmpty(source.MainImage))
            return null;

        var request = httpContextAccessor.HttpContext.Request;
        return $"{request.Scheme}://{request.Host}{source.MainImage}";
    }
}