using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Features.Services.Commands.Add;
using AutoMapper;
using SharedKernel;

namespace Application.Features.Gallery.Commands.Add;

public class AddGalleryCommandHandler(IMapper mapper, IRepository<Domain.Models.Services.Entities.Gallery> repository,IUploadImage uploadImage) : ICommandHandler<AddGalleryCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(AddGalleryCommand request, CancellationToken cancellationToken)
    {
        var gallery = mapper.Map<Domain.Models.Services.Entities.Gallery>(request);
        if (request.Image != null && request.Image.Length > 0)
        {
            // Save file and set ImageUrl on the entity
            var relativePath = await uploadImage.SaveFileAsync(request.Image, "Gallery");
            gallery.ImageUrl = relativePath;
        }
        
        
        
        await repository.AddAsync(gallery, cancellationToken);
        return Result.Success(gallery.Id);
    }
}