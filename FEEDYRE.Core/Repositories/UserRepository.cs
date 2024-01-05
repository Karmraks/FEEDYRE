using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FEEDYRE.Core.Abstractions.Interfaces;
using FEEDYRE.Core.Data;
using FEEDYRE.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FEEDYRE.Core.Repositories
{
    public class UserRepository(DataContext context) : IUserRepository
    {
        public async Task Create(User user)
        {
            user.Id = Guid.NewGuid();
            await context.AddAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task<bool> IsRegistered(User user)
        {
            return await context.Users.AnyAsync(u => u.Email == user.Email);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User?> Get(User user)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);
        }
    }
}
