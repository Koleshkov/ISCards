using AutoMapper;
using ISCards.Data;
using ISCards.Data.Entities;
using ISCards.Models;
using Microsoft.EntityFrameworkCore;

namespace ISCards.Services.Repositories.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<ApplicationContext> dbFactory;
        private readonly IMapper mapper;

        public UserRepository(IDbContextFactory<ApplicationContext> dbFactory, IMapper mapper)
        {
            this.dbFactory=dbFactory;
            this.mapper=mapper;
        }

        public async Task<bool> Any()
        {
            using var context = await dbFactory.CreateDbContextAsync();
            return context.Users.Any();
        }

        public async Task CreateUserAsync(UserDTO user)
        {
            using var context = await dbFactory.CreateDbContextAsync();

            await context.AddAsync(mapper.Map<User>(user));

            await context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(UserDTO user)
        {
            using var context = await dbFactory.CreateDbContextAsync();

            context.Update(mapper.Map<User>(user));

            await context.SaveChangesAsync();
        }

        public async Task<UserDTO> GetUserAsync()
        {
            using var context = await dbFactory.CreateDbContextAsync();

            var user = await context.Users.FirstOrDefaultAsync();

            return mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            using var context = await dbFactory.CreateDbContextAsync();

            var user = await context.Users.FirstOrDefaultAsync(u => u.Id==id);

            return mapper.Map<UserDTO>(user);
        }
    }
}
