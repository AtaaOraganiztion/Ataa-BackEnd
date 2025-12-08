using Application.Features.News.Commands.Add;
using Application.Features.News.Commands.Delete;
using Application.Features.News.Dtos;
using AutoMapper;
using Domain.Models.News.Entities;

namespace Application.Mapping.News;

public class NewsProfile : Profile
{
    public NewsProfile()
    {
        CreateMap<AddNewsCommand, Domain.Models.News.Entities.News>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()))
            .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
        
        CreateMap<Domain.Models.News.Entities.News,AddNewsCommand>()
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<NewsUrlResolver>());
        CreateMap<AddNewsCommand, Section>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()))
            .ForMember(dest => dest.NewsId, opt => opt.Ignore())
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
        
        CreateMap<Domain.Models.News.Entities.News, Section>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()))
            .ForMember(dest => dest.NewsId, opt => opt.Ignore())
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
        
        CreateMap<UpdateSectionDto, Section>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
        
        CreateMap<UpdateNewsDto, Domain.Models.News.Entities.News>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
        CreateMap<UpdateSectionDto, Section>();
        
        CreateMap<Domain.Models.News.Entities.News, UpdateNewsDto>();
        CreateMap<DeleteNewsCommand, Domain.Models.News.Entities.News>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => true));
        
        CreateMap<SectionDto, Section>();
        CreateMap<Section, SectionDto>();
        
        CreateMap<Domain.Models.News.Entities.News, GetNewsDto>();
        CreateMap<GetNewsDto, Domain.Models.News.Entities.News>();
    }
}