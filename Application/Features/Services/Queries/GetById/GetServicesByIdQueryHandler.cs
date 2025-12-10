using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Services.Dtos;
using Application.Features.Services.Specifications;
using AutoMapper;
using Domain.Models.News;
using Domain.Models.Services;
using SharedKernel;

namespace Application.Features.Services.Queries.GetById;

public class GetServicesByIdQueryHandler(IRepository<Domain.Models.Services.Entities.Services> repository, IMapper mapper) : IQueryHandler<GetServicesByIdQuery, GetServicesDto>
{
    public async Task<Result<GetServicesDto>> Handle(GetServicesByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Models.Services.Entities.Services? services = await repository.FirstOrDefaultAsync(new ServicesByIdSpec(request.Id), cancellationToken);
        if (services is null)
        {
            return Result.Failure<GetServicesDto>(Error.NotFound(ServicesMessageKeys.ServicesNotFound));
        }
        GetServicesDto servicesDto = mapper.Map<GetServicesDto>(services);
        return Result.Success(servicesDto);
    }
}