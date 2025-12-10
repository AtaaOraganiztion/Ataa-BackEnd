using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Features.Dtos;
using Application.Features.Features.Specifications;
using Application.Features.Gallery.Dtos;
using Application.Features.Gallery.Specifications;
using AutoMapper;
using Domain.Models.News;
using SharedKernel;

namespace Application.Features.Gallery.Queries.GetById;

public class GetGalleryByIdQueryHandler(IRepository<Domain.Models.Services.Entities.Gallery> repository, IMapper mapper) : IQueryHandler<GetGalleryByIdQuery, GetGalleryDto>
{
    public async Task<Result<GetGalleryDto>> Handle(GetGalleryByIdQuery request, CancellationToken cancellationToken)
    {
        Domain.Models.Services.Entities.Gallery? gallery = await repository.FirstOrDefaultAsync(new GalleryByIdSpec(request.Id), cancellationToken);
        if (gallery is null)
        {
            return Result.Failure<GetGalleryDto>(Error.NotFound(ServicesMessageKeys.GalleryNotFound));
        }
        GetGalleryDto galleryDto = mapper.Map<GetGalleryDto>(gallery);
        return Result.Success(galleryDto);
    }
}