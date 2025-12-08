using Application.Abstractions.Messaging;

namespace Application.Features.Opinions.Commands.Delete;

public record DeleteOpinionsCommand(Ulid Id) : ICommand<Ulid>;