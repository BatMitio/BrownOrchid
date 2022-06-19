using BrownOrchid.Services.App.Data.Entities;

namespace BrownOrchid.Services.App.Data.Views;

public class DiscountView
{
    public string DiscountId { get; set; }
    public string DealerId { get; set; }
    public int Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Discount.DiscountStatusEnum DiscountStatus { get; set; }
}