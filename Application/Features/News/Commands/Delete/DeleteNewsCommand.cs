using Application.Abstractions.Messaging;

namespace Application.Features.News.Commands.Delete;

public record DeleteNewsCommand(Ulid Id) : ICommand<Ulid>;