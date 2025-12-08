using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Domain.Models.News.Entities;

namespace Application.Features.Statics.Commands.Add;

public record AddStaticsCommand( 
    Ulid ServiceId,
    int Number,
    string Title
    
    ) : ICommand<Ulid>;