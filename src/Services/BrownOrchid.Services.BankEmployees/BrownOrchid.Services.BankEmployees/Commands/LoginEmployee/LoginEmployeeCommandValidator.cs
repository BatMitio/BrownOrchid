using BrownOrchid.Services.BankEmployees.Data.Repositories.Interfaces;
using FluentValidation;

namespace BrownOrchid.Services.BankEmployees.Commands.LoginEmployee;

public class LoginEmployeeCommandValidator : AbstractValidator<LoginEmployeeCommand>
{
    public LoginEmployeeCommandValidator(IBankEmployeeRepository repository)
    {
        RuleFor(c => c.Username)
            .MustAsync(async (username, _) => await repository.FindByUsernameAsync(username) is not null)
            .WithErrorCode("400")
            .WithMessage("An employee with the given username does not exist in the database!");
    }
}