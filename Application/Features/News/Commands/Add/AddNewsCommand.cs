using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Domain.Models.News.Entities;

namespace Application.Features.News.Commands.Add;

public record AddNewsCommand( string Title,
 string Description,
 string Category,
 string? ImageUrl,
 string? Qoute,
 DateTime PublishedOnUtc
    
    ) : ICommand<Ulid>;