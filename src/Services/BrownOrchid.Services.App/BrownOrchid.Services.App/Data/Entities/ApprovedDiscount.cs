using System.ComponentModel.DataAnnotations;
using BrownOrchid.Common.Domain.Entities;

namespace BrownOrchid.Services.App.Data.Entities;

public class ApprovedDiscount : Entity<string>
{
    public string EmployeeId { get; set; }
    public string DiscountId { get; set; }

    public ApprovedDiscount()
    {
        Id = Guid.NewGuid().ToString();
    }
}