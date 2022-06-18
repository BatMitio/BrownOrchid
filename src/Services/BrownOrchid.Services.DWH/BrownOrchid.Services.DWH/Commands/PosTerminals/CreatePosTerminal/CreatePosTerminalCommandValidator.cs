using BrownOrchid.Services.DWH.Data.Repositories.Interfaces;
using FluentValidation;

namespace BrownOrchid.Services.DWH.Commands.PosTerminals.CreatePosTerminal;

public class CreatePosTerminalCommandValidator : AbstractValidator<CreatePosTerminalCommand>
{
    public CreatePosTerminalCommandValidator(IDealerRepository repository)
    {
        RuleFor(cmd => cmd.DealerUsername)
            .MustAsync(async (username, _) => await repository.FindByUsernameAsync(username) is not null)
            .WithErrorCode("400")
            .WithMessage("A dealer with the given username does not exist in the database!");
    }
}