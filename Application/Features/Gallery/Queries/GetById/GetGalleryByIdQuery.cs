using Application.Abstractions.Messaging;
using Application.Features.Features.Dtos;
using Application.Features.Gallery.Dtos;
using Application.Features.Opinions.Dtos;
using Application.Features.Sections.Dtos;

namespace Application.Features.Gallery.Queries.GetById;

public record GetGalleryByIdQuery(Ulid Id) : IQuery<GetGalleryDto>;