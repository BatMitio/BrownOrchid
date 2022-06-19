using BrownOrchid.Common.Domain.Entities;
using BrownOrchid.Services.App.Data.Persistence;
using BrownOrchid.Services.App.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.App.Data.Repositories;

public class PosTerminalRepository : IPosTerminalRepository
{
    private AppDbContext _context;

    public PosTerminalRepository(AppDbContext context)
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
        var result = _context.PosTerminals.Update(terminal);
        
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<PosTerminal?> FindByUsernameAsync(string terminalId)
    {
        return await _context.PosTerminals.Where(p => p.TerminalId == terminalId).FirstOrDefaultAsync();
    }
}