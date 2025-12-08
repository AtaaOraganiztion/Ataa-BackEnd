using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Application.Features.Opinions.Dtos;
using Application.Features.Services.Dtos;
using Application.Features.Statics.Dtos;

namespace Application.Features.Opinions.Commands.Update;

public record UpdateOpinionsCommand(Ulid Id, UpdateOpinionsDto OpinionsDto) : ICommand<Ulid>;
