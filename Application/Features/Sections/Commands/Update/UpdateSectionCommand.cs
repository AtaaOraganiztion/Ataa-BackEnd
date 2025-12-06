using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Application.Features.Sections.Dtos;

namespace Application.Features.Sections.Commands.Update;

public record UpdateSectionCommand(Ulid Id, SectionsDto SectionsDto) : ICommand<Ulid>;
