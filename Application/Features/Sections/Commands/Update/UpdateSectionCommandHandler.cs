using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.News.Specifications;
using Application.Features.Sections.Specifications;
using AutoMapper;
using Domain.Models.News;
using Domain.Models.News.Entities;
using SharedKernel;

namespace Application.Features.Sections.Commands.Update;

public class UpdateSectionCommandHandler(IMapper mapper, IRepository<Domain.Models.News.Entities.Section> repository) : ICommandHandler<UpdateSectionCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
    {
        var section = await repository.FirstOrDefaultAsync(new SectionByIdSpec(request.Id), cancellationToken);
        if (section is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(NewsMessageKeys.SectionNotFound));
        }
        var updatedsection = mapper.Map(request.SectionsDto, section);
        await repository.UpdateAsync(updatedsection, cancellationToken);
        return Result.Success(updatedsection.Id);
    }
}