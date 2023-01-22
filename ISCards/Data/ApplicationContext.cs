using ISCards.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ISCards.Data
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> opt) : base(opt)
        {
            Database.EnsureCreated();
        }

        public DbSet<PassengerCard> PassangerCards { get; set; }
        public DbSet<SafetyCard> SafetyCards { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
