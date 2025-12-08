using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Domain.Models.News.Entities;

namespace Application.Features.Features.Commands.Add;

public record AddFeaturesCommand( 
    Ulid ServiceId,
    string Title,
    string Desc,
    string? Benifit
    
    ) : ICommand<Ulid>;