using System.Security.Claims;
using BrownOrchid.Common.Application.Jwt.Interfaces;
using BrownOrchid.Common.Domain.Types;
using BrownOrchid.Services.BankEmployees.Data.Repositories.Interfaces;
using MediatR;

namespace BrownOrchid.Services.BankEmployees.Commands.LoginEmployee;

public class LoginEmployeeCommand : IRequest<ApiResponse<string?>>
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginEmployeeCommandHandler : IRequestHandler<LoginEmployeeCommand, ApiResponse<string?>>
{
    private IBankEmployeeRepository _repository;
    private ITokenGenerator _tokenGenertor;

    public LoginEmployeeCommandHandler(IBankEmployeeRepository repository, ITokenGenerator tokenGenertor)
    {
        _repository = repository;
        _tokenGenertor = tokenGenertor;
    }

    public async Task<ApiResponse<string?>> Handle(LoginEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _repository.FindByUsernameAsync(request.Username);
        if (BCrypt.Net.BCrypt.Verify(request.Password, employee!.PasswordHash))
        {
            return new ApiResponse<string?>(_tokenGenertor.GenerateToken(new[]
            {
                new Claim("role", "employee"),
                new Claim("id", employee.Id)
            }));
        }

        return new ApiResponse<string?>(null, "Fail!", new[] { "Invalid credentials!" });
    }
}