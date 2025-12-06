using Application.Features.News.Commands.Add;
using Application.Features.News.Commands.Delete;
using Application.Features.News.Dtos;
using Application.Features.Sections.Commands.Add;
using Application.Features.Sections.Commands.Delete;
using Application.Features.Sections.Commands.Update;
using Application.Features.Sections.Dtos;
using AutoMapper;
using Domain.Models.News.Entities;

namespace Application.Mapping.Sections;

public class SectionProfile : Profile
{
    public SectionProfile()
    {
        CreateMap<AddSectionCommand, Domain.Models.News.Entities.Section>()
            .ForMember(dest => dest.NewsId, opt => opt.MapFrom(src => src.NewsId))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
        
        CreateMap<AddNewsCommand, Domain.Models.News.Entities.Section>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
        
        CreateMap<UpdateSectionCommand, Section>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
        
        CreateMap<SectionsDto, Domain.Models.News.Entities.Section>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
        CreateMap<Section, SectionsDto>();
        
        CreateMap<DeleteSectionCommand, Domain.Models.News.Entities.Section>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => true));

        CreateMap<Domain.Models.News.Entities.News, Section>();
        
        CreateMap<Domain.Models.News.Entities.Section, GetSectionsDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.NewsId, opt => opt.MapFrom(src => src.NewsId))
            .ForMember(dest => dest.Heading, opt => opt.MapFrom(src => src.Heading))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content));

        CreateMap<GetSectionsDto, Domain.Models.News.Entities.Section>();
        
    }
}