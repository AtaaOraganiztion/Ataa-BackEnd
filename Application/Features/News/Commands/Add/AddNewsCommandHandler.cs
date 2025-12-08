using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using AutoMapper;
using SharedKernel;

namespace Application.Features.News.Commands.Add;

public class AddNewsCommandHandler(IMapper mapper, IRepository<Domain.Models.News.Entities.News> repository,IUploadImage uploadImage) : ICommandHandler<AddNewsCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(AddNewsCommand request, CancellationToken cancellationToken)
    {
        var news = mapper.Map<Domain.Models.News.Entities.News>(request);
        if (request.ImageFile != null && request.ImageFile.Length > 0)
        {
            // Save file and set ImageUrl on the entity
            var relativePath = await uploadImage.SaveFileAsync(request.ImageFile, "News");
            news.ImageUrl = relativePath;
        }
        await repository.AddAsync(news, cancellationToken);
        return Result.Success(news.Id);
    }
}