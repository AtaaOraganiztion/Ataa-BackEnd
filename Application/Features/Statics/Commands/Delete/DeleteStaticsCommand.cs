using Application.Abstractions.Messaging;

namespace Application.Features.Statics.Commands.Delete;

public record DeleteStaticsCommand(Ulid Id) : ICommand<Ulid>;