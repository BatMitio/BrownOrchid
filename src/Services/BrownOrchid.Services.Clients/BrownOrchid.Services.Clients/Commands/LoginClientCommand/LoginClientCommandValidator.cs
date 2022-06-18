using BrownOrchid.Services.Clients.Data.Repositories.Interfaces;
using FluentValidation;

namespace BrownOrchid.Services.Clients.Commands.LoginClientCommand;

public class LoginClientCommandValidator : AbstractValidator<LoginClientCommand>
{
    public LoginClientCommandValidator(IClientRepository repository)
    {
        RuleFor(c => c.Username)
            .MustAsync(async (username, _) => await repository.FindByUsernameAsync(username) is not null)
            .WithErrorCode("400")
            .WithMessage("Invalid credentials!");
    }
}