using Application.Abstractions.Messaging;

namespace Application.Features.ContactForm.Commands.Delete;

public record DeleteContactFormCommand(Ulid Id) : ICommand<Ulid>;