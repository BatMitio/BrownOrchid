using BrownOrchid.Services.App.Data.Entities;

namespace BrownOrchid.Services.App.Data.Repositories.Interfaces;

public interface IApprovalRepository
{
    public Task<ApprovedDiscount?> ApproveAsync(string employeeId, string discountId);
    public Task<List<ApprovedDiscount>> FindAllByDiscountIdAsync(string requestDiscountId);
}