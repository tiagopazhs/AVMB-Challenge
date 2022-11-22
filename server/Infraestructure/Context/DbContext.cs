using Microsoft.EntityFrameworkCore;
using server.Domain.Entity;
namespace server.Infraestructure.Context;
public class ApiContext : DbContext
{
    protected override void OnConfiguring
   (DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "AvmbDb");
    }
    public DbSet<Envelope> Envelopes { get; set; }
}