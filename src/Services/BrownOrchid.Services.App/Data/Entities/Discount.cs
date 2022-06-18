namespace BrownOrchid.Services.App.Data.Entities;

public class Discount
{
    public string DiscountId { get; set; }
    public Dealer Dealer { get; set; }
    public int Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public DiscountStatusEnum DiscountStatus { get; set; }

    public enum DiscountStatusEnum
    {
        ACTIVE,
        EXPIRED,
        REJECTED,
        WAITING
    }
}