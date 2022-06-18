using BrownOrchid.Services.Clients.Data.Entities;

namespace BrownOrchid.Services.Clients.Data.Repositories.Interfaces;

public interface IClientRepository
{
    public Task<Client?> SaveAsync(Client employee);
    public Task<Client?> FindByUsernameAsync(string username);
}