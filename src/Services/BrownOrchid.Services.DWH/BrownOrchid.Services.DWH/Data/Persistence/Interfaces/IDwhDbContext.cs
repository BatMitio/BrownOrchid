using BrownOrchid.Common.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BrownOrchid.Services.DWH.Data.Persistence.Interfaces;

public interface IDwhDbContext
{
    public DbSet<Dealer> Dealers { get; set; }
    public DbSet<BankEmployee> BankEmployees { get; set; }
    public DbSet<PosTerminal> PosTerminals { get; set; }
    public int SaveChanges();
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    
}