using Application.Abstractions.Messaging;
using Application.Abstractions.Services;
using Application.Features.Gallery.Dtos;
using Application.Features.News.Dtos;
using Application.Features.Services.Dtos;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Gallery.Commands.Update;

public record UpdateGalleryCommand(Ulid Id, UpdateGalleryDto UpdateGalleryDto) : ICommand<Ulid>;
