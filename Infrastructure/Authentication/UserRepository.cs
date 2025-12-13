using Application.Abstractions;
using Domain.Identities;
using Domain.Identities.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Database;
using System;

namespace Infrastructure.Authentication
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) => _context = context;

        public async Task<User?> GetByEmailAsync(string email) =>
            await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

        public async Task<User> CreateAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
