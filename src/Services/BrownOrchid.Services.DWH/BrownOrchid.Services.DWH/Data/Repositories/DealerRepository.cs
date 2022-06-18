using BrownOrchid.Common.Domain.Entities;
using BrownOrchid.Services.DWH.Data.Persistence.Interfaces;
using BrownOrchid.Services.DWH.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.DWH.Data.Repositories;

public class DealerRepository : IDealerRepository
{
    private IDwhDbContext _context;

    public DealerRepository(IDwhDbContext context)
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