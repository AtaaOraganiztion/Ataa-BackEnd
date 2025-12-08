using Application.Abstractions.Messaging;
using Application.Features.News.Dtos;
using Application.Features.Features.Dtos;
using Application.Features.Opinions.Dtos;
using Application.Features.Statics.Dtos;

namespace Application.Features.Opinions.Queries.GetAll;

public record GetOpinionsQuery(OpinionsFilter OpinionsFilter) : IQuery<List<GetOpinionsDto>>;