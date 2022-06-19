namespace BrownOrchid.Services.App.DTOs;

public class CreateDiscountDto
{
    public int Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndTime { get; set; }
}