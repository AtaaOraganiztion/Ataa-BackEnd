
using Application.Abstractions.Messaging;

namespace Application.Features.Sections.Commands.Add;

public record AddSectionCommand(
    Ulid NewsId,
    string Heading,
    string Content
    
    ) : ICommand<Ulid>;