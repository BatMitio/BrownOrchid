using BrownOrchid.Common.Domain.Entities;
using BrownOrchid.Services.App.Data.Views;

namespace BrownOrchid.Services.App.Data.Repositories.Interfaces;

public interface IDealerRepository
{
    public Task<Dealer?> SaveAsync(Dealer dealer);
    public Task<Dealer?> FindByUsernameAsync(string username);
    public Task<Dealer?> FindByIdAsync(string requestDealerId);
    public Task<List<DealerView>> FIndAllAsync();
}