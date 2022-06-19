namespace BrownOrchid.Gateways.Portal.Data.Models.Discount;

public class DiscountModel
{
    public int Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public DiscountModel()
    {
    }

    public DiscountModel(int amount, DateTime startDate, DateTime endDate)
    {
        Amount = amount;
        StartDate = startDate;
        EndDate = endDate;
    }
}