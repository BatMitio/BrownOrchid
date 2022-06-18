using BrownOrchid.Common.Domain.Entities;
using BrownOrchid.Services.DWH.Data.Persistence;
using BrownOrchid.Services.DWH.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.DWH.Data.Repositories;

public class PosTerminalRepository : IPosTerminalRepository
{
    private DwhDbContext _context;

    public PosTerminalRepository(DwhDbContext context)
    {
        _context = context;
    }

    public async Task<PosTerminal?> SaveAsync(PosTerminal terminal)
    {
        var result = _context.PosTerminals.Add(terminal);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<PosTerminal?> UpdateAsync(PosTerminal terminal)
    {
        _context.Entry(terminal.Dealer).State = EntityState.Unchanged;
        var result = _context.PosTerminals.Update(terminal);
        
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<PosTerminal?> FindByUsernameAsync(string terminalId)
    {
        return await _context.PosTerminals.Where(p => p.TerminalId == terminalId).FirstOrDefaultAsync();
    }
}