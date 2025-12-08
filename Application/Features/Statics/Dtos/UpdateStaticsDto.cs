using Domain.Models.News.Entities;

namespace Application.Features.Statics.Dtos;

public record UpdateStaticsDto(
    int? Number,
    string? Title
    );