using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Application.Features.Features.Dtos;
using Application.Features.Gallery.Dtos;
using Application.Features.Statics.Dtos;

namespace Application.Features.Gallery.Queries.GetAll;

public record GetGalleryQuery(GalleryFilter GalleryFilter) : IQuery<List<GetGalleryDto>>;