using BrownOrchid.Common.Domain.Entities;
using BrownOrchid.Services.App.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.App.Data.Persistence;

public class AppDbContext : DbContext
{
    public DbSet<Dealer> Dealers { get; set; }
    public DbSet<PosTerminal> PosTerminals { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<ApprovedDiscount> Approvals { get; set; }
    
    public AppDbContext()
    {
        
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}