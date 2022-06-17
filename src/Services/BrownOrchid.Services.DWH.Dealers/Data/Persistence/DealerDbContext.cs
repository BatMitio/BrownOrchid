using BrownOrchid.Services.DWH.Dealers.Data.Entities;
using BrownOrchid.Services.DWH.Dealers.Data.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.DWH.Dealers.Data.Persistence;

public class DealerDbContext : DbContext, IDealerDbContext
{
    public DbSet<Dealer> Dealers { get; set; }

    protected DealerDbContext()
    {
    }

    public DealerDbContext(DbContextOptions options) : base(options)
    {
    }
}