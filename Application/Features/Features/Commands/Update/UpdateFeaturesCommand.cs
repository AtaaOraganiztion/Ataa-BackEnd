using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Application.Features.Services.Dtos;

namespace Application.Features.Features.Commands.Update;

public record UpdateFeaturesCommand(Ulid Id, UpdateFeaturesDto FeaturesDto) : ICommand<Ulid>;
