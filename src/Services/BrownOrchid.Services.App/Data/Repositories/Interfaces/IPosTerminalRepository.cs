﻿using BrownOrchid.Services.App.Data.Entities;

namespace BrownOrchid.Services.App.Data.Repositories.Interfaces;

public interface IPosTerminalRepository
{
    public Task<PosTerminal?> SaveAsync(PosTerminal terminal);
    public Task<PosTerminal?> UpdateAsync(PosTerminal terminal);
    public Task<PosTerminal?> FindByUsernameAsync(string terminalId);
}