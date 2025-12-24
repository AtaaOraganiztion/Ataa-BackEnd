using Application.Abstractions.Messaging;
using Application.Features.ContactForm.Dtos;
using Application.Features.News.Dtos;
using Application.Features.Features.Dtos;
using Application.Features.Opinions.Dtos;
using Application.Features.Statics.Dtos;

namespace Application.Features.ContactForm.Queries.GetAll;

public record GetContactFormQuery(ContactFormFilter ContactFormFilter) : IQuery<List<GetContactFormDto>>;