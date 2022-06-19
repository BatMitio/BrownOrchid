using AutoMapper;
using BrownOrchid.Services.App.Data.Entities;
using BrownOrchid.Services.App.Data.Persistence;
using BrownOrchid.Services.App.Data.Repositories.Interfaces;
using BrownOrchid.Services.App.Data.Views;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.App.Data.Repositories;

public class DiscountRepository : IDiscountRepository
{
    private AppDbContext _context;
    private IMapper _mapper;

    public DiscountRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Discount?> SaveAsync(Discount discount)
    {
        var result = _context.Discounts.Add(discount);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Discount?> FindByIdAsync(string discountId)
    {
        return await _context.Discounts.FindAsync(discountId);
    }

    public async Task UpdateAsync(Discount discount)
    {
        _context.Discounts.Update(discount);
        await _context.SaveChangesAsync();
    }

    public async Task<List<DiscountView>> FIndAllAsync()
    {
        return (await _context.Discounts.ToListAsync()).Select(d => _mapper.Map<DiscountView>(d)).ToList();
    }
}