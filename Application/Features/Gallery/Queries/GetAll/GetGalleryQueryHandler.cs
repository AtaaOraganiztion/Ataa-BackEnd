using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Features.Dtos;
using Application.Features.News.Dtos;
using Application.Features.News.Specifications;
using Application.Features.Features.Specifications;
using Application.Features.Gallery.Dtos;
using Application.Features.Gallery.Specifications;
using AutoMapper;
using SharedKernel;

namespace Application.Features.Gallery.Queries.GetAll;

public class GetGalleryQueryHandler(IRepository<Domain.Models.Services.Entities.Gallery> repository, IMapper mapper) : IQueryHandler<GetGalleryQuery, List<GetGalleryDto>>
{
    public async Task<Result<List<GetGalleryDto>>> Handle(GetGalleryQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Models.Services.Entities.Gallery> galleries = await repository.ListAsync(
            new GetGallerySpec(request.GalleryFilter),
            cancellationToken);
            
        List<GetGalleryDto> galleryDtos= mapper.Map<List<GetGalleryDto>>(galleries);
        return Result.Success(galleryDtos);
    }
}