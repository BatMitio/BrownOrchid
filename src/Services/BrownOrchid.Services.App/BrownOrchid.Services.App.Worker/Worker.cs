using BrownOrchid.Common.Domain.Entities;
using BrownOrchid.Services.App.Data.Persistence;
using BrownOrchid.Services.DWH.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.App.Worker;

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
            var appDbContext = scope.ServiceProvider.GetService<AppDbContext>()!;
            
            List<Dealer> dealersRegistered = dwhDbContext.Dealers.ToList();
            foreach (var dealer in dealersRegistered)
            {
                if ((await appDbContext.Dealers.FindAsync(dealer.Id)) is null)
                {
                    await appDbContext.Dealers.AddAsync(dealer, stoppingToken);
                    await appDbContext.SaveChangesAsync(stoppingToken);
                }
                else
                {
                    appDbContext.Entry(await appDbContext.Dealers.FindAsync(dealer.Id)).State = EntityState.Detached;
                    appDbContext.Dealers.Update(dealer);
                    await appDbContext.SaveChangesAsync(stoppingToken);
                }
            }
            
            
            
            List<PosTerminal> terminalsRegistered = dwhDbContext.PosTerminals.ToList();
            foreach (var terminal in terminalsRegistered)
            {
                if ((await appDbContext.PosTerminals.FindAsync(terminal.TerminalId)) is null)
                {
                    await appDbContext.PosTerminals.AddAsync(terminal, stoppingToken);
                    await appDbContext.SaveChangesAsync(stoppingToken);
                }
                else
                {
                    appDbContext.Entry(await appDbContext.PosTerminals.FindAsync(terminal.TerminalId)).State = EntityState.Detached;
                    appDbContext.PosTerminals.Update(terminal);
                    await appDbContext.SaveChangesAsync(stoppingToken);
                }
            }
            
            await Task.Delay(1000, stoppingToken);
        }
    }
}