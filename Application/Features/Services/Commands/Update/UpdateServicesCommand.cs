using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Application.Features.Services.Dtos;

namespace Application.Features.Services.Commands.Update;

public record UpdateServicesCommand(Ulid Id, UpdateServicesDto ServicesDto) : ICommand<Ulid>;
