using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.News.Specifications;
using Application.Features.Sections.Specifications;
using Domain.Models.News;
using SharedKernel;

namespace Application.Features.Sections.Commands.Delete;

public class DeleteSectionCommandHandler(IRepository<Domain.Models.News.Entities.Section> repository) : ICommandHandler<DeleteSectionCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
    {
        var section = await repository.FirstOrDefaultAsync(new SectionByIdSpec(request.Id),cancellationToken);
        if (section is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(NewsMessageKeys.SectionNotFound));
        }

        await repository.DeleteAsync(section, cancellationToken);
        return Result.Success(section.Id);
    }
}