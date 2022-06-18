
using BrownOrchid.Common.Domain.Entities;

namespace BrownOrchid.Services.DWH.Data.Repositories.Interfaces;

public interface IBankEmployeeRepository
{
    public Task<BankEmployee?> SaveAsync(BankEmployee employee);
    public Task<BankEmployee?> FindByUsernameAsync(string username);
}