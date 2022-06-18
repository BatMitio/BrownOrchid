using BrownOrchid.Common.Domain.Entities;
using BrownOrchid.Services.BankEmployees.Data.Persistence;
using BrownOrchid.Services.BankEmployees.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.BankEmployees.Data.Repositories;

public class BankEmployeeRepository : IBankEmployeeRepository
{
    private BankEmployeesDbContext _context;

    public BankEmployeeRepository(BankEmployeesDbContext context)
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