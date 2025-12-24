using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Domain.Models.ContactForm.Enums;
using Domain.Models.News.Entities;

namespace Application.Features.ContactForm.Commands.Add;

public record AddContactFormCommand( 
    string Name,
    string EntityName,
    string Email,
    string Phone,
    RequestType RequestType,
    string Message
    
    ) : ICommand<Ulid>;