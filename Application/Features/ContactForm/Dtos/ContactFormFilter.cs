using Domain.Models.ContactForm.Enums;

namespace Application.Features.ContactForm.Dtos;

public record ContactFormFilter(
    string? Name,
    string? EntityName,
    string? Email,
    string? Phone,
    RequestType? RequestType,
    string? Message
    );