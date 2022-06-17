using BrownOrchid.Services.DWH.Data.Entities;

namespace BrownOrchid.Services.DWH.Data.Repositories.Interfaces;

public interface IDealerRepository
{
    public Task<Dealer?> SaveDealerAsync(Dealer dealer);
    public Task<Dealer?> FindByUsername(string username);
}