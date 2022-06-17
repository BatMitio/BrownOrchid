using BrownOrchid.Services.DWH.Data.Repositories.Interfaces;
using FluentValidation;

namespace BrownOrchid.Services.DWH.Commands.Dealers.LoginDealer;

public class LoginDealerCommandValidator : AbstractValidator<LoginDealerCommand>
{
    public LoginDealerCommandValidator(IDealerRepository repository)
    {
        RuleFor(cmd => cmd.Username)
            .MustAsync(async (username, _) => (await repository.FindByUsernameAsync(username)) is not null)
            .WithErrorCode("404")
            .WithMessage("A user with the given username could not be found!");
    }
}