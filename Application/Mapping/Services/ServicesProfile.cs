using Application.Features.News.Dtos;
using Application.Features.Services.Commands.Add;
using Application.Features.Services.Dtos;
using AutoMapper;

namespace Application.Mapping.Services;

public class ServicesProfile : Profile
{
    public ServicesProfile()
    {
        CreateMap<AddServicesCommand, Domain.Models.Services.Entities.Services>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()))
            .ForMember(dest => dest.MainImage, opt => opt.Ignore())
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
        
         CreateMap<Domain.Models.Services.Entities.Services,AddServicesCommand>()
             .ForMember(dest => dest.MainImage, opt => opt.MapFrom<ServiceUrlResolver>());
         
        CreateMap<UpdateServicesDto, Domain.Models.Services.Entities.Services>();
        CreateMap<Domain.Models.Services.Entities.Services, UpdateServicesDto>();
        
        CreateMap<Domain.Models.Services.Entities.Services, GetServicesDto>();
        CreateMap<GetServicesDto, Domain.Models.Services.Entities.Services>();
    }
}