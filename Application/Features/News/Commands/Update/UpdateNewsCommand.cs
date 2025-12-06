using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;

namespace Application.Features.News.Commands.Update;

public record UpdateNewsCommand(Ulid Id, UpdateNewsDto NewsDto) : ICommand<Ulid>;
