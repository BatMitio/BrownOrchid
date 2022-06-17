using BrownOrchid.Services.DWH.Data.Repositories.Interfaces;
using FluentValidation;

namespace BrownOrchid.Services.DWH.Commands.BankEmployees.CreateBankEmployee;

public class CreateBankEmployeeCommandValidator : AbstractValidator<CreateBankEmployeeCommand>
{
    public CreateBankEmployeeCommandValidator(IBankEmployeeRepository repository)
    {
        RuleFor(cmd => cmd.Username)
            .MustAsync(async (username, _) => (await repository.FindByUsernameAsync(username) is null))
            .WithErrorCode("409")
            .WithMessage("The username already exists in the database!");
    }
}