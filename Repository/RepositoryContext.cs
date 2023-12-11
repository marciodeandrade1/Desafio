using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set;}
        public DbSet<Logradouro> Logradouros { get; set;}
    }
}
