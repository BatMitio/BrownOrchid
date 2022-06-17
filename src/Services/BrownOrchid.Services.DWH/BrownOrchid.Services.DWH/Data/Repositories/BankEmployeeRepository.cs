using BrownOrchid.Services.DWH.Data.Entities;
using BrownOrchid.Services.DWH.Data.Persistence.Interfaces;
using BrownOrchid.Services.DWH.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.DWH.Data.Repositories;

public class BankEmployeeRepository : IBankEmployeeRepository
{
    private IDwhDbContext _context;

    public BankEmployeeRepository(IDwhDbContext context)
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