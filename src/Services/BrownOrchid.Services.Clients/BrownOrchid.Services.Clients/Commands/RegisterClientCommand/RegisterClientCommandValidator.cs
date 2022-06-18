using BrownOrchid.Services.Clients.Data.Repositories.Interfaces;
using FluentValidation;

namespace BrownOrchid.Services.Clients.Commands.RegisterClientCommand;

public class RegisterClientCommandValidator : AbstractValidator<RegisterClientCommand>
{
    public RegisterClientCommandValidator(IClientRepository repository)
    {
        RuleFor(c => c.Username)
            .MustAsync(async (username, _) => await repository.FindByUsernameAsync(username) is null)
            .WithErrorCode("400")
            .WithMessage("Username unavailable!");
        
        RuleFor(c => c.Password)
            .Must(password =>  password.Length >= 8)
            .WithErrorCode("400")
            .WithMessage("Password must be at least 8 symbols!");
        
        RuleFor(c => c.Password)
            .Must(password =>  password.Any(char.IsUpper))
            .WithErrorCode("400")
            .WithMessage("Password must have at least one uppercase character!");
        
        RuleFor(c => c.Password)
            .Must(password =>  password.Any(char.IsDigit))
            .WithErrorCode("400")
            .WithMessage("Password must have at least one digit!");
        
        RuleFor(c => c.PhoneNumber)
            .Must(phoneNumber =>  phoneNumber.Substring(0, 1) == "0" || phoneNumber.Substring(0, 4) == "+359")
            .WithErrorCode("400")
            .WithMessage("Phone number must begin either with 0 or +359!");
    }
}