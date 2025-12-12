using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Abstractions.Services;
using Application.Features.News.Specifications;
using Application.Features.Services.Specifications;
using AutoMapper;
using Domain.Models.News;
using Domain.Models.News.Entities;
using SharedKernel;

namespace Application.Features.Services.Commands.Update;

public class UpdateServicesCommandHandler(IMapper mapper, IRepository<Domain.Models.Services.Entities.Services> repository,IUploadImage uploadImage) : ICommandHandler<UpdateServicesCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(UpdateServicesCommand request, CancellationToken cancellationToken)
    {
        var services = await repository.FirstOrDefaultAsync(new ServicesByIdSpec(request.Id), cancellationToken);
        if (services is null)
        {
            return Result.Failure<Ulid>(Error.NotFound(ServicesMessageKeys.ServicesNotFound));
        }
        var updatedServices = mapper.Map(request.ServicesDto, services);
        if (request.ServicesDto.ImageFile != null && request.ServicesDto.ImageFile.Length > 0)
        {
            if (!string.IsNullOrEmpty(services.MainImage))
            {
                await uploadImage.DeleteFileAsync(services.MainImage);
            }

            var relativePath = await uploadImage.SaveFileAsync(request.ServicesDto.ImageFile, "Services");
            updatedServices.MainImage = relativePath;
        }
        await repository.UpdateAsync(updatedServices, cancellationToken);
        return Result.Success(updatedServices.Id);
    }
}