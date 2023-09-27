using CharacterManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CharacterManager.Infra.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Personagem> Personagens { get; set; }
        public DbSet<LogBatalha> LogsBatalha { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }

}
