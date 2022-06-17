using BrownOrchid.Services.DWH.BankEmployees.Data.Entities;
using BrownOrchid.Services.DWH.BankEmployees.Data.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.DWH.BankEmployees.Data.Persistence;

public class BankEmployeeDbContext : DbContext, IBankEmployeeDbContext
{
    public DbSet<BankEmployee> BankEmployees { get; set; }

    protected BankEmployeeDbContext()
    {
    }

    public BankEmployeeDbContext(DbContextOptions options) : base(options)
    {
    }
}