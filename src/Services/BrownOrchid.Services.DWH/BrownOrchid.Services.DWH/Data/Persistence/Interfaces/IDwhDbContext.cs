using BrownOrchid.Services.DWH.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.DWH.Data.Persistence.Interfaces;

public interface IDwhDbContext
{
    public DbSet<Dealer> Dealers { get; set; }
    public DbSet<BankEmployee> BankEmployees { get; set; }
    public DbSet<PosTerminal> PosTerminals { get; set; }
    public int SaveChanges();
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}