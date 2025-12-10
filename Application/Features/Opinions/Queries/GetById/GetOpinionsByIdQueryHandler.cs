using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Opinions.Dtos;
using Application.Features.Opinions.Specifications;
using AutoMapper;
using Domain.Models.News;
using Domain.Models.Opinions;
using SharedKernel;

namespace Application.Features.Opinions.Queries.GetById;

public class GetOpinionsByIdQueryHandler(IRepository<Domain.Models.Opinions.Entities.Opinions> repository, IMapper mapper) : IQueryHandler<GetOpinionsByIdQuery, GetOpinionsDto>
{
    public async Task<Result<GetOpinionsDto>> Handle(GetOpinionsByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Models.Opinions.Entities.Opinions? opinions = await repository.FirstOrDefaultAsync(new OpinionsByIdSpec(request.Id), cancellationToken);
        if (opinions is null)
        {
            return Result.Failure<GetOpinionsDto>(Error.NotFound(OpinionsMessageKeys.OpinionsNotFound));
        }
        GetOpinionsDto opinionsDto = mapper.Map<GetOpinionsDto>(opinions);
        return Result.Success(opinionsDto);
    }
}