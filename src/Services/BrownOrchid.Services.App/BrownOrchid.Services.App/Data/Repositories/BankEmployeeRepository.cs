using BrownOrchid.Common.Domain.Entities;
using BrownOrchid.Services.App.Data.Persistence;
using BrownOrchid.Services.App.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.App.Data.Repositories;

public class BankEmployeeRepository : IBankEmployeeRepository
{
    private AppDbContext _context;

    public BankEmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<BankEmployee?> SaveAsync(BankEmployee employee)
    {
        var result = _context.BankEmployees.Add(employee);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<BankEmployee?> FindByUsernameAsync(string username)
    {
        return await _context.BankEmployees.Where(e => e.UserName == username).FirstOrDefaultAsync();
    }
}