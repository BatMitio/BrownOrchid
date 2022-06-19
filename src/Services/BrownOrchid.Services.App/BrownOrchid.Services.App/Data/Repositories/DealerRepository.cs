using AutoMapper;
using BrownOrchid.Common.Domain.Entities;
using BrownOrchid.Services.App.Data.Persistence;
using BrownOrchid.Services.App.Data.Repositories.Interfaces;
using BrownOrchid.Services.App.Data.Views;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.App.Data.Repositories;

public class DealerRepository : IDealerRepository
{
    private AppDbContext _context;
    private IMapper _mapper;

    public DealerRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Dealer?> SaveAsync(Dealer dealer)
    {
        var result = _context.Dealers.Add(dealer);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Dealer?> FindByUsernameAsync(string username)
    {
        var dealer = await _context.Dealers.Where(d => d.UserName == username).FirstOrDefaultAsync();
        return dealer;
    }

    public async Task<Dealer?> FindByIdAsync(string requestDealerId)
    {
        return await _context.Dealers.FindAsync(requestDealerId);
    }

    public async Task<List<DealerView>> FIndAllAsync()
    {
        var list = (await _context.Dealers.ToListAsync());
        var listView = list.Select(d => _mapper.Map<DealerView>(d))
            .ToList();
        return listView;
    }
}