using BrownOrchid.Services.App.Data.Entities;

namespace BrownOrchid.Gateways.Portal.Views.Discounts;

public class DiscountEntryView
{
    public string DealerId { get; set; }
    public string DiscountId { get; set; }
    public int Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Discount.DiscountStatusEnum Status { get; set; }
}