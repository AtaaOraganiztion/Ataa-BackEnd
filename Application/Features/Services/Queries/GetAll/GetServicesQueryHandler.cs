using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.News.Dtos;
using Application.Features.News.Specifications;
using Application.Features.Services.Dtos;
using Application.Features.Services.Specifications;
using AutoMapper;
using SharedKernel;

namespace Application.Features.Services.Queries.GetAll;

public class GetServicesQueryHandler(IRepository<Domain.Models.Services.Entities.Services> repository, IMapper mapper) : IQueryHandler<GetServicesQuery, List<GetServicesDto>>
{
    public async Task<Result<List<GetServicesDto>>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Models.Services.Entities.Services> servicesList = await repository.ListAsync(
            new GetServicesSpec(request.ServicesFilter),
            cancellationToken);
            
        List<GetServicesDto> servicesDtos = mapper.Map<List<GetServicesDto>>(servicesList);
        return Result.Success(servicesDtos);
    }
}