using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Gallery.Specifications;
using Application.Features.Statics.Specifications;
using Domain.Models.News;
using SharedKernel;

namespace Application.Features.Gallery.Commands.Delete;

public class DeleteGalleryCommandHandler(IRepository<Domain.Models.Services.Entities.Gallery> repository) : ICommandHandler<DeleteGalleryCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(DeleteGalleryCommand request, CancellationToken cancellationToken)
    {
        var gallery = await repository.FirstOrDefaultAsync(new GalleryByIdSpec(request.Id),cancellationToken);
        if (gallery is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(ServicesMessageKeys.GalleryNotFound));
        }

        await repository.DeleteAsync(gallery, cancellationToken);
        return Result.Success(gallery.Id);
    }
}