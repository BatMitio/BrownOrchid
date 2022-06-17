using BrownOrchid.Services.DWH.Data.Entities;
using BrownOrchid.Services.DWH.Data.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.DWH.Data.Persistence;

public class DwhDbContext : DbContext, IDwhDbContext
{
    public DbSet<Dealer> Dealers { get; set; }
    public DbSet<BankEmployee> BankEmployees { get; set; }
    public DbSet<PosTerminal> PosTerminals { get; set; }
    
    public DwhDbContext()
    {
    }

    public DwhDbContext(DbContextOptions options) : base(options)
    {
    }
    
    
}