using BrownOrchid.Services.App.Data.Repositories.Interfaces;
using FluentValidation;

namespace BrownOrchid.Services.App.Commands.LoginDealerCommand;

public class LoginEmployeeCommandValidator : AbstractValidator<LoginDealerCommand>
{
    public LoginEmployeeCommandValidator(IDealerRepository repository)
    {
        RuleFor(c => c.Username)
            .MustAsync(async (username, _) => await repository.FindByUsernameAsync(username) is not null)
            .WithErrorCode("400")
            .WithMessage("A dealer with the given username does not exist in the database!");
    }
}