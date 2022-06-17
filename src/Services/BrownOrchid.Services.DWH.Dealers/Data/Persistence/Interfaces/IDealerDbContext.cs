using BrownOrchid.Services.DWH.Dealers.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.DWH.Dealers.Data.Persistence.Interfaces;

public interface IDealerDbContext
{
    public DbSet<Dealer> Dealers { get; set; }

    public int SaveChanges();

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}