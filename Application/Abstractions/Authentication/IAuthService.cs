using Application.Features.Authentication.Dtos;

namespace Application.Abstractions
{
    public interface IAuthService
    {
        Task<AuthResponseDto?> LoginAsync(LoginRequestDto request);
        Task<AuthResponseDto?> RegisterAsync(LoginRequestDto request);
    }
}
