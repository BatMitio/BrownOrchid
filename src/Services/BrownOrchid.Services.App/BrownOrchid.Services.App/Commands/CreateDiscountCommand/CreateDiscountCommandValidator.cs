using BrownOrchid.Services.App.Data.Repositories.Interfaces;
using FluentValidation;

namespace BrownOrchid.Services.App.Commands.CreateDiscountCommand;

public class CreateDiscountCommandValidator : AbstractValidator<CreateDiscountCommand>
{
    public CreateDiscountCommandValidator(IDealerRepository repository)
    {
        RuleFor(c => c.DealerId)
            .MustAsync(async (id, _) => await repository.FindByIdAsync(id) is not null)
            .WithErrorCode("400")
            .WithMessage("No such dealer exists in the database");
    }
}