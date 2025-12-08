using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using AutoMapper;
using SharedKernel;

namespace Application.Features.Services.Commands.Add;

public class AddServicesCommandHandler(IMapper mapper, IRepository<Domain.Models.Services.Entities.Services> repository,IUploadImage fileUpload) : ICommandHandler<AddServicesCommand,Ulid>
{
    public async Task<Result<Ulid>> Handle(AddServicesCommand request, CancellationToken cancellationToken)
    {
        var services = mapper.Map<Domain.Models.Services.Entities.Services>(request);
        if (request.ImageFile != null && request.ImageFile.Length > 0)
        {
            // Save file and set ImageUrl on the entity
            var relativePath = await fileUpload.SaveFileAsync(request.ImageFile, "Services");
            services.MainImage = relativePath;
        }
        await repository.AddAsync(services, cancellationToken);
        return Result.Success(services.Id);
    }
}