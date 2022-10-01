using ISCards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISCards.Services.UserRepositories
{
    public interface IUserRepository
    {
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> GetUserAsync();
        Task CreateUserAsync(UserDTO user);
        Task UpdateUserAsync(UserDTO user);
        Task<bool> Any();
    }
}
