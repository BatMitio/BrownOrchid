using BrownOrchid.Services.App.Data.Entities;
using BrownOrchid.Services.App.Data.Persistence;
using BrownOrchid.Services.App.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.App.Data.Repositories;

public class ApprovalRepository : IApprovalRepository
{
    private AppDbContext _context;

    public ApprovalRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ApprovedDiscount?> ApproveAsync(string employeeId, string discountId)
    {
        var approval = new ApprovedDiscount() { EmployeeId = employeeId, DiscountId = discountId };
        approval = _context.Approvals.Add(approval).Entity;
        await _context.SaveChangesAsync();
        return approval;
    }

    public async Task<List<ApprovedDiscount>> FindAllByDiscountIdAsync(string requestDiscountId)
    {
        return await _context.Approvals.Where(a => a.DiscountId == requestDiscountId).ToListAsync();
    }
}