using ISCards.Models;

namespace ISCards.Services.Repositories.UserRepositories
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
