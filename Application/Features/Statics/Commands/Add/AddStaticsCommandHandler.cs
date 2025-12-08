using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Services.Commands.Add;
using AutoMapper;
using SharedKernel;

namespace Application.Features.Statics.Commands.Add;

public class AddStaticsCommandHandler(IMapper mapper, IRepository<Domain.Models.Services.Entities.Statics> repository) : ICommandHandler<AddStaticsCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(AddStaticsCommand request, CancellationToken cancellationToken)
    {
        var statics = mapper.Map<Domain.Models.Services.Entities.Statics>(request);

        await repository.AddAsync(statics, cancellationToken);
        return Result.Success(statics.Id);
    }
}