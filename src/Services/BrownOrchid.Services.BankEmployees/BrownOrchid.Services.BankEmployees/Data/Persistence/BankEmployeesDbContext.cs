using BrownOrchid.Common.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.BankEmployees.Data.Persistence;

public class BankEmployeesDbContext : DbContext
{
    public DbSet<BankEmployee> BankEmployees { get; set; }

    public BankEmployeesDbContext()
    {
        
    }

    public BankEmployeesDbContext(DbContextOptions<BankEmployeesDbContext> options) : base(options)
    {
    }
}