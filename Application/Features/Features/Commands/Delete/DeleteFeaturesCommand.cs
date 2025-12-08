using Application.Abstractions.Messaging;

namespace Application.Features.Features.Commands.Delete;

public record DeleteFeaturesCommand(Ulid Id) : ICommand<Ulid>;