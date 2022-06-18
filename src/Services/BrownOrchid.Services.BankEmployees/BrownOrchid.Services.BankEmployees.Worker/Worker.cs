using BrownOrchid.Common.Domain.Entities;
using BrownOrchid.Services.BankEmployees.Data.Persistence;
using BrownOrchid.Services.DWH.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.BankEmployees.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly IServiceScopeFactory _scopeFactory;

    public Worker(ILogger<Worker> logger, IServiceScopeFactory scopeFactory)
    {
        _logger = logger;
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var scope = _scopeFactory.CreateScope();
            var dwhDbContext = scope.ServiceProvider.GetService<DwhDbContext>()!;
            var employeesDbContext = scope.ServiceProvider.GetService<BankEmployeesDbContext>()!;
            
            List<BankEmployee> employeesRegistered = dwhDbContext.BankEmployees.ToList();
            foreach (var employee in employeesRegistered)
            {
                if ((await employeesDbContext.BankEmployees.FindAsync(employee.Id)) is null)
                {
                    await employeesDbContext.BankEmployees.AddAsync(employee, stoppingToken);
                    await employeesDbContext.SaveChangesAsync(stoppingToken);
                }
                else
                {
                    employeesDbContext.Entry(await employeesDbContext.BankEmployees.FindAsync(employee.Id)).State = EntityState.Detached;
                    employeesDbContext.BankEmployees.Update(employee);
                    await employeesDbContext.SaveChangesAsync(stoppingToken);
                }
            }
            
            await Task.Delay(1000, stoppingToken);
        }
    }
}