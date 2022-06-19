using BrownOrchid.Common.Domain.Types;
using BrownOrchid.Services.App.Data.Views;

namespace BrownOrchid.Gateways.Portal.Services.Dealer.Interfaces;

public interface IDealerService
{
    Task<ApiResponse<string?>> LoginDealerAsync(string? username, string? password);
    
    Task<List<DealerView>> GetAllDealersAsync();
    Task<List<DiscountView>> GetAvailableDiscounts();
    Task<List<DiscountView>> GetAllDiscountsAsync();
    Task<List<DiscountView>> GetAllWaitingDiscounts();
    Task<List<PosTerminalView>> GetAllTerminalsAsync();
    Task<ApiResponse<string?>> CreateDiscount(int amount, DateTime startDate, DateTime endDate);
}