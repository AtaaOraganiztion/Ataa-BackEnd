using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Application.Features.Services.Dtos;

namespace Application.Features.Services.Queries.GetAll;

public record GetServicesQuery(ServicesFilter ServicesFilter) : IQuery<List<GetServicesDto>>;