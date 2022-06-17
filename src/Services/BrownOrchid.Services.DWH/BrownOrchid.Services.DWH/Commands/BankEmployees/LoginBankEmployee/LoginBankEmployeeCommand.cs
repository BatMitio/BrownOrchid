using BrownOrchid.Common.Application.Jwt.Interfaces;
using BrownOrchid.Common.Domain.Types;
using BrownOrchid.Services.DWH.Data.Repositories.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace BrownOrchid.Services.DWH.Commands.BankEmployees.LoginBankEmployee;

public class LoginBankEmployeeCommand : IRequest<ApiResponse<string>>
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginBankEmployeeCommandHandler : IRequestHandler<LoginBankEmployeeCommand, ApiResponse<string>>
{
    private IBankEmployeeRepository _repository;
    private IConfiguration _configuration;

    private ITokenGenerator _tokenGenerator;

    //TODO: Set to an adequate value in production
    private const int ExpirationInMinutes = 3000;

    public LoginBankEmployeeCommandHandler(IBankEmployeeRepository repository, IConfiguration configuration, ITokenGenerator tokenGenerator)
    {
        _repository = repository;
        _configuration = configuration;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ApiResponse<string>> Handle(LoginBankEmployeeCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.FindByUsernameAsync(request.Username);

        if (BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            var token = _tokenGenerator.GenerateToken();

            return new ApiResponse<string>(token, "Successfully created a token");
        }

        return new ApiResponse<string>("An error occured when logging!", "", new[] { "The password you provided is incorrect!" });
    }
}