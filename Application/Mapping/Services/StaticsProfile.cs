using Application.Features.Statics.Commands.Add;
using Application.Features.Statics.Commands.Delete;
using Application.Features.Statics.Dtos;
using AutoMapper;

namespace Application.Mapping.Services;

public class StaticsProfile : Profile
{
    public StaticsProfile()
    {
        CreateMap<AddStaticsCommand, Domain.Models.Services.Entities.Statics>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));

        CreateMap<UpdateStaticsDto, Domain.Models.Services.Entities.Statics>();
        CreateMap<Domain.Models.Services.Entities.Statics, UpdateStaticsDto>();
        
        CreateMap<Domain.Models.Services.Entities.Statics, GetStaticsDto>();
        CreateMap<GetStaticsDto, Domain.Models.Services.Entities.Statics>();
        
        CreateMap<DeleteStaticsCommand,Domain.Models.Services.Entities.Statics>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => true));
    }
}