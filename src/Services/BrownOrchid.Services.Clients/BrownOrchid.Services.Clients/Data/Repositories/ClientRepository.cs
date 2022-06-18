using BrownOrchid.Services.Clients.Data.Entities;
using BrownOrchid.Services.Clients.Data.Persistence;
using BrownOrchid.Services.Clients.Data.Repositories.Interfaces;

namespace BrownOrchid.Services.Clients.Data.Repositories;

public class ClientRepository : IClientRepository
{
    private ClientsDbContext _context;

    public ClientRepository(ClientsDbContext context)
    {
        _context = context;
    }

    public async Task<Client?> SaveAsync(Client employee)
    {
        var client = _context.Clients.Add(employee);
        await _context.SaveChangesAsync();
        return client.Entity;
    }

    public async Task<Client?> FindByUsernameAsync(string username)
    {
        return await _context.Clients.FindAsync(username);
    }
}