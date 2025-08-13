using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Duka.Domain.Users
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
    }
}