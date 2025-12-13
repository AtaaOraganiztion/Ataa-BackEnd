namespace Application.Features.Authentication.Dtos
{
    public class LoginRequestDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

    }
}
