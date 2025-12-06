using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using AutoMapper;
using SharedKernel;

namespace Application.Features.Sections.Commands.Add;

public class AddSectionCommandHandler(IMapper mapper, IRepository<Domain.Models.News.Entities.Section> repository) : ICommandHandler<AddSectionCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(AddSectionCommand request, CancellationToken cancellationToken)
    {
        var sections = mapper.Map<Domain.Models.News.Entities.Section>(request);

        await repository.AddAsync(sections, cancellationToken);
        return Result.Success(sections.Id);
    }
}