
using BrownOrchid.Services.App.Data.Entities;

namespace BrownOrchid.Services.App.Data.Repositories.Interfaces;

public interface IBankEmployeeRepository
{
    public Task<BankEmployee?> SaveAsync(BankEmployee employee);
    public Task<BankEmployee?> FindByUsernameAsync(string username);
}