using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Domain.Models.News.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Features.News.Commands.Add;

public record AddNewsCommand( string Title,
 string Description,
 string Category,
 string? ImageUrl,
 IFormFile ? ImageFile,
 string? Qoute,
 DateTime PublishedOnUtc
    
    ) : ICommand<Ulid>;