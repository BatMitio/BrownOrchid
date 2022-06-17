using BrownOrchid.Services.DWH.Data.Repositories.Interfaces;
using FluentValidation;

namespace BrownOrchid.Services.DWH.Commands.Dealers.CreateDealer;

public class CreateDealerCommandValidator : AbstractValidator<CreateDealerCommand>
{
    public CreateDealerCommandValidator(IDealerRepository dealerRepository)
    {
        RuleFor(cmd => cmd.Username)
            .MustAsync(async (username, _) => (await dealerRepository.FindByUsernameAsync(username) is null))
            .WithErrorCode("409")
            .WithMessage("Username not available for registration!");
    }
}