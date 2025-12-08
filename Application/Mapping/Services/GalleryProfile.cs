using Application.Features.Gallery.Commands.Add;
using Application.Features.Gallery.Dtos;
using AutoMapper;

namespace Application.Mapping.Services;

public class GalleryProfile : Profile
{
    public GalleryProfile()
    {
        CreateMap<AddGalleryCommand, Domain.Models.Services.Entities.Gallery>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()))
            .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
        
        CreateMap<Domain.Models.Services.Entities.Gallery,AddGalleryCommand>()
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<GalleryUrlResolver>());
         

        
        CreateMap<Domain.Models.Services.Entities.Gallery, GetGalleryDto>();
        CreateMap<GetGalleryDto, Domain.Models.Services.Entities.Gallery>();
    }
}