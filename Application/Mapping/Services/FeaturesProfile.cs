using Application.Features.Features.Commands.Add;
using Application.Features.Features.Commands.Delete;
using Application.Features.Features.Dtos;
using Application.Features.Services.Commands.Add;
using Application.Features.Services.Dtos;
using AutoMapper;

namespace Application.Mapping.Services;

public class FeaturesProfile : Profile
{
    public FeaturesProfile()
    {
        CreateMap<AddFeaturesCommand, Domain.Models.Services.Entities.Features>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));

        CreateMap<UpdateFeaturesDto, Domain.Models.Services.Entities.Features>();
        CreateMap<Domain.Models.Services.Entities.Features, UpdateFeaturesDto>();
        
        CreateMap<Domain.Models.Services.Entities.Features, GetFeaturesDto>();
        CreateMap<GetFeaturesDto, Domain.Models.Services.Entities.Features>();
        
        CreateMap<DeleteFeaturesCommand,Domain.Models.Services.Entities.Features>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => true));
    }
}