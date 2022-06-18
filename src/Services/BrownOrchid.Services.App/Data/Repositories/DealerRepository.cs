using BrownOrchid.Services.App.Data.Entities;
using BrownOrchid.Services.App.Data.Persistence;
using BrownOrchid.Services.App.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.App.Data.Repositories;

public class DealerRepository : IDealerRepository
{
    private AppDbContext _context;

    public DealerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Dealer?> SaveAsync(Dealer dealer)
    {
        var result = _context.Dealers.Add(dealer);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Dealer?> FindByUsernameAsync(string username)
    {
        var dealer = await _context.Dealers.Where(d => d.UserName == username).FirstOrDefaultAsync();
        return dealer;
    }
}