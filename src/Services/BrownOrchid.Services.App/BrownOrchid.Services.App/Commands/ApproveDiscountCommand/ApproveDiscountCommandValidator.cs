using BrownOrchid.Services.App.Data.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.App.Commands.ApproveDiscountCommand;

public class ApproveDiscountCommandValidator : AbstractValidator<ApproveDiscountCommand>
{
    public ApproveDiscountCommandValidator(AppDbContext context)
    {
        RuleFor(c => c)
            .MustAsync(async (c, _) =>
                await context.Approvals
                    .FirstOrDefaultAsync(a => a.DiscountId == c.DiscountId && 
                                              a.EmployeeId == c.EmployeeId) is null)
            .WithErrorCode("400")
            .WithMessage("The employee has already approved the discount!");
    }
}