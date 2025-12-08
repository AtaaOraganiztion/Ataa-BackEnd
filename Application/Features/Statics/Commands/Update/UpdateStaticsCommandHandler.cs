using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.News.Specifications;
using Application.Features.Features.Specifications;
using Application.Features.Statics.Specifications;
using AutoMapper;
using Domain.Models.News;
using Domain.Models.News.Entities;
using SharedKernel;

namespace Application.Features.Statics.Commands.Update;

public class UpdateStaticsCommandHandler(IMapper mapper, IRepository<Domain.Models.Services.Entities.Statics> repository) : ICommandHandler<UpdateStaticsCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateStaticsCommand request, CancellationToken cancellationToken)
    {
        var features = await repository.FirstOrDefaultAsync(new StaticsByIdSpec(request.Id), cancellationToken);
        if (features is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(ServicesMessageKeys.StaticsNotFound));
        }
        var updatedStatics = mapper.Map(request.StaticsDto, features);
        await repository.UpdateAsync(updatedStatics, cancellationToken);
        return Result.Success(updatedStatics.Id);
    }
}