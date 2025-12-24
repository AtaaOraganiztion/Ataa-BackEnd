using Application.Features.ContactForm.Commands.Add;
using Application.Features.ContactForm.Commands.Delete;
using Application.Features.ContactForm.Dtos;
using AutoMapper;

namespace Application.Mapping.ContactForm;

public class ContactFormProfile : Profile
{
    public ContactFormProfile()
    {
        CreateMap<AddContactFormCommand, Domain.Models.ContactForm.Entities.ContactForm>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));

        CreateMap<UpdateContactFormDto, Domain.Models.ContactForm.Entities.ContactForm>();
        CreateMap<Domain.Models.ContactForm.Entities.ContactForm, UpdateContactFormDto>();
        
        CreateMap<Domain.Models.ContactForm.Entities.ContactForm, GetContactFormDto>();
        CreateMap<GetContactFormDto, Domain.Models.ContactForm.Entities.ContactForm>();
        
        CreateMap<DeleteContactFormCommand,Domain.Models.ContactForm.Entities.ContactForm>()
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => true));
    }
}