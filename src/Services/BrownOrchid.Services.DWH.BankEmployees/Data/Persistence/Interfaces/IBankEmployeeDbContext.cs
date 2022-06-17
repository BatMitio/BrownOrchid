using BrownOrchid.Services.DWH.BankEmployees.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.DWH.BankEmployees.Data.Persistence.Interfaces;

public interface IBankEmployeeDbContext
{
    public DbSet<BankEmployee> BankEmployees { get; set; }

    public int SaveChanges();

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}