using Application.Abstractions.Messaging;

namespace Application.Features.Services.Commands.Delete;

public record DeleteServicesCommand(Ulid Id) : ICommand<Ulid>;