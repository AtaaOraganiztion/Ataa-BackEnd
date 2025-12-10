using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Application.Features.Services.Dtos;

namespace Application.Features.Services.Queries.GetById;

public record GetServicesByIdQuery(Ulid Id) : IQuery<GetServicesDto>;