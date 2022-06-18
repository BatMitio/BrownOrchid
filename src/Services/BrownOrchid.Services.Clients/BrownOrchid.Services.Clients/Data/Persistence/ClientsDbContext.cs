using BrownOrchid.Services.Clients.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.Clients.Data.Persistence;

public class ClientsDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }

    public ClientsDbContext()
    {
        
    }

    public ClientsDbContext(DbContextOptions<ClientsDbContext> options) : base(options)
    {
    }
}