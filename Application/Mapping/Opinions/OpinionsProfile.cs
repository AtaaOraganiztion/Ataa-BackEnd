using Application.Features.Opinions.Commands.Add;
using Application.Features.Opinions.Dtos;
using AutoMapper;

namespace Application.Mapping.Opinions;

public class OpinionsProfile : Profile
{
    public OpinionsProfile()
    {
        CreateMap<AddOpinionsCommand, Domain.Models.Opinions.Entities.Opinions>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));

        CreateMap<UpdateOpinionsDto, Domain.Models.Opinions.Entities.Opinions>();
        CreateMap<Domain.Models.Opinions.Entities.Opinions, UpdateOpinionsDto>();
        
        CreateMap<Domain.Models.Opinions.Entities.Opinions, GetOpinionsDto>();
        CreateMap<GetOpinionsDto, Domain.Models.Opinions.Entities.Opinions>();
    }
}