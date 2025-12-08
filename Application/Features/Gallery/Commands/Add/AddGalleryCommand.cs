using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Domain.Models.News.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Gallery.Commands.Add;

public record AddGalleryCommand( 
    Ulid ServiceId,
    IFormFile? Image,
    string? ImageUrl
    
    ) : ICommand<Ulid>;