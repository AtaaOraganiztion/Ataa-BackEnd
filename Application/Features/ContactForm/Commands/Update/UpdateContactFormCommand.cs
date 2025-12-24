using Application.Abstractions.Messaging;
using Application.Features.ContactForm.Dtos;
using Application.Features.News.Dtos;
using Application.Features.Opinions.Dtos;
using Application.Features.Services.Dtos;
using Application.Features.Statics.Dtos;

namespace Application.Features.ContactForm.Commands.Update;

public record UpdateContactFormCommand(Ulid Id, UpdateContactFormDto? ContactFormDto) : ICommand<Ulid>;
