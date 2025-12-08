using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Application.Features.News.Dtos;
using Application.Features.Services.Dtos;
using Domain.Models.News.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Services.Commands.Add;

public record AddServicesCommand( string Title,
    string ShortDesc,
    string LongDesc,
    string? MainImage,
    IFormFile? ImageFile
    
    ) : ICommand<Ulid>;