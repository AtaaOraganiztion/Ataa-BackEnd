using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Application.Features.Services.Dtos;
using Application.Features.Statics.Dtos;

namespace Application.Features.Statics.Commands.Update;

public record UpdateStaticsCommand(Ulid Id, UpdateStaticsDto StaticsDto) : ICommand<Ulid>;
