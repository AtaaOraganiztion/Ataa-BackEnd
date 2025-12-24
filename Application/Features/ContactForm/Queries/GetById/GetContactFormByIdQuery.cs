using Application.Abstractions.Messaging;
using Application.Features.ContactForm.Dtos;
using Application.Features.Opinions.Dtos;
using Application.Features.Sections.Dtos;

namespace Application.Features.ContactForm.Queries.GetById;

public record GetContactFormByIdQuery(Ulid Id) : IQuery<GetContactFormDto>;