using Domain.Identities;
using Domain.Identities.Entities;

namespace Application.Abstractions
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User> CreateAsync(User user);
    }
}
