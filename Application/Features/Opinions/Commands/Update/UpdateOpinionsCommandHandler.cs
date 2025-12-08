using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.News.Specifications;
using Application.Features.Features.Specifications;
using Application.Features.Opinions.Specifications;
using AutoMapper;
using Domain.Models.News;
using Domain.Models.News.Entities;
using Domain.Models.Opinions;
using SharedKernel;

namespace Application.Features.Opinions.Commands.Update;

public class UpdateOpinionsCommandHandler(IMapper mapper, IRepository<Domain.Models.Opinions.Entities.Opinions> repository) : ICommandHandler<UpdateOpinionsCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateOpinionsCommand request, CancellationToken cancellationToken)
    {
        var opinions = await repository.FirstOrDefaultAsync(new OpinionsByIdSpec(request.Id), cancellationToken);
        if (opinions is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(OpinionsMessageKeys.OpinionsNotFound));
        }
        var updatedOpinions = mapper.Map(request.OpinionsDto, opinions);
        await repository.UpdateAsync(updatedOpinions, cancellationToken);
        return Result.Success(updatedOpinions.Id);
    }
}