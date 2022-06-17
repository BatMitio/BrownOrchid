using BrownOrchid.Services.DWH.Data.Entities;

namespace BrownOrchid.Services.DWH.Data.Repositories.Interfaces;

public interface IDealerRepository
{
    public Task<Dealer?> SaveAsync(Dealer dealer);
    public Task<Dealer?> FindByUsernameAsync(string username);
}