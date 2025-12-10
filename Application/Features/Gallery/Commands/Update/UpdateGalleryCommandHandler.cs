using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Features.Gallery.Specifications;
using AutoMapper;
using Domain.Models.News;
using Domain.Models.News.Entities;
using SharedKernel;

namespace Application.Features.Gallery.Commands.Update;

public class UpdateGalleryCommandHandler(IMapper mapper, IRepository<Domain.Models.Services.Entities.Gallery> repository,IUploadImage uploadImage) : ICommandHandler<UpdateGalleryCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateGalleryCommand request, CancellationToken cancellationToken)
    {
        var gallery = await repository.FirstOrDefaultAsync(new GalleryByIdSpec(request.Id), cancellationToken);
        if (gallery is null)
        {
            return Result.Failure<Ulid>(Error.NotFound("Gallery not found"));
        }

        var updatedGallery = mapper.Map(request.UpdateGalleryDto, gallery);

        if (request.UpdateGalleryDto.ImageFile != null && request.UpdateGalleryDto.ImageFile.Length > 0)
        {
            if (!string.IsNullOrEmpty(gallery.ImageUrl))
            {
                await uploadImage.DeleteFileAsync(gallery.ImageUrl);
            }

            var relativePath = await uploadImage.SaveFileAsync(request.UpdateGalleryDto.ImageFile, "Gallery");
            updatedGallery.ImageUrl = relativePath;
        }

        await repository.UpdateAsync(updatedGallery, cancellationToken);
        return Result.Success(updatedGallery.Id);
    }
}