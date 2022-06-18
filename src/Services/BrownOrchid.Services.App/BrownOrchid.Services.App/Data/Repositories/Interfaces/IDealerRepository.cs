using BrownOrchid.Common.Domain.Entities;

namespace BrownOrchid.Services.App.Data.Repositories.Interfaces;

public interface IDealerRepository
{
    public Task<Dealer?> SaveAsync(Dealer dealer);
    public Task<Dealer?> FindByUsernameAsync(string username);
}