using Domain.Models.ContactForm.Enums;
using Domain.Models.News.Entities;

namespace Application.Features.ContactForm.Dtos;

public record UpdateContactFormDto(
    string? Name,
    string? EntityName,
    string? Email,
    string? Phone,
    RequestType? RequestType,
    string? Message
    );