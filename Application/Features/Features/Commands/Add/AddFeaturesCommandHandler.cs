using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Services.Commands.Add;
using AutoMapper;
using SharedKernel;

namespace Application.Features.Features.Commands.Add;

public class AddFeaturesCommandHandler(IMapper mapper, IRepository<Domain.Models.Services.Entities.Features> repository) : ICommandHandler<AddFeaturesCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(AddFeaturesCommand request, CancellationToken cancellationToken)
    {
        var features = mapper.Map<Domain.Models.Services.Entities.Features>(request);

        await repository.AddAsync(features, cancellationToken);
        return Result.Success(features.Id);
    }
}