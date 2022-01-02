using Microsoft.EntityFrameworkCore;
using NetCoreReactJwt.Domain.Clientcs;
using NetCoreReactJwt.Domain.Entities;

namespace NetCoreReactJwt.Infrastructure.Data
{
    public class ContextDBConexao : DbContext
    {
        public ContextDBConexao(DbContextOptions<ContextDBConexao> options) : base(options)
        {
        }
        public DbSet<Scheduling> Schedules { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
            });
        }
    }
}
