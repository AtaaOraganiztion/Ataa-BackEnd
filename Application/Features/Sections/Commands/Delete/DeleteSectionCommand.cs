using Application.Abstractions.Messaging;

namespace Application.Features.Sections.Commands.Delete;

public record DeleteSectionCommand(Ulid Id) : ICommand<Ulid>;