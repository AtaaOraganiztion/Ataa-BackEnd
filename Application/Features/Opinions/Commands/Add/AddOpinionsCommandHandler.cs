using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Services.Commands.Add;
using AutoMapper;
using SharedKernel;

namespace Application.Features.Opinions.Commands.Add;

public class AddOpinionsCommandHandler(IMapper mapper, IRepository<Domain.Models.Opinions.Entities.Opinions> repository) : ICommandHandler<AddOpinionsCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(AddOpinionsCommand request, CancellationToken cancellationToken)
    {
        var opinions = mapper.Map<Domain.Models.Opinions.Entities.Opinions>(request);

        await repository.AddAsync(opinions, cancellationToken);
        return Result.Success(opinions.Id);
    }
}