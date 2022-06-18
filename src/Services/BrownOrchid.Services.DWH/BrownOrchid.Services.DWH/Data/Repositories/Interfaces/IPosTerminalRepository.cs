using BrownOrchid.Common.Domain.Entities;

namespace BrownOrchid.Services.DWH.Data.Repositories.Interfaces;

public interface IPosTerminalRepository
{
    public Task<PosTerminal?> SaveAsync(PosTerminal terminal);
    public Task<PosTerminal?> UpdateAsync(PosTerminal terminal);
    public Task<PosTerminal?> FindByUsernameAsync(string terminalId);
}