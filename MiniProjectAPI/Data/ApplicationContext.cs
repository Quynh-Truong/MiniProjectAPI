using Microsoft.EntityFrameworkCore;
using MiniProjectAPI.Models;

namespace MiniProjectAPI.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Interest> Interests { get; set; }

        public DbSet<InterestLink> InterestLinks { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

    }
}
