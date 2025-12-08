using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Domain.Models.News.Entities;

namespace Application.Features.Opinions.Commands.Add;

public record AddOpinionsCommand( 
    string Name,
    string Role,
    int Rating,
    string Content,
    string AvatarKey
    
    ) : ICommand<Ulid>;