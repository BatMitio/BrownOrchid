using BrownOrchid.Services.App.Data.Entities;
using BrownOrchid.Services.App.Data.Views;

namespace BrownOrchid.Services.App.Data.Repositories.Interfaces;

public interface IDiscountRepository
{
    public Task<Discount?> SaveAsync(Discount discount);
    public Task<Discount?> FindByIdAsync(string discountId);
    public Task UpdateAsync(Discount discount);
    public Task<List<DiscountView>> FIndAllAsync();
}