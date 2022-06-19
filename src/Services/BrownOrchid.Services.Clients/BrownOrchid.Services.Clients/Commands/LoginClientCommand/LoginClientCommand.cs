using System.Security.Claims;
using AutoMapper;
using BrownOrchid.Common.Application.Jwt.Interfaces;
using BrownOrchid.Common.Domain.Types;
using BrownOrchid.Services.Clients.Data.Entities;
using BrownOrchid.Services.Clients.Data.Repositories.Interfaces;
using MediatR;

namespace BrownOrchid.Services.Clients.Commands.LoginClientCommand;

public class LoginClientCommand : IRequest<ApiResponse<string?>>
{
    public string? Username { get; set; }
    public string? Password { get; set; }

    public LoginClientCommand()
    {
    }

    public LoginClientCommand(string? username, string? password)
    {
        Username = username;
        Password = password;
    }
}

public class LoginClientCommandHandler : IRequestHandler<LoginClientCommand, ApiResponse<string?>>
{
    private IClientRepository _repository;
    private ITokenGenerator _tokenGenerator;

    public LoginClientCommandHandler(IClientRepository repository, ITokenGenerator tokenGenerator)
    {
        _repository = repository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ApiResponse<string?>> Handle(LoginClientCommand request, CancellationToken cancellationToken)
    {
        var client = await _repository.FindByUsernameAsync(request.Username);

        if (BCrypt.Net.BCrypt.Verify(request.Password, client.PasswordHash))
        {
            return new ApiResponse<string?>(
                _tokenGenerator.GenerateToken(new[] { new Claim("role", "client") }));
        }

        return new ApiResponse<string?>(null, "Fail", new[] { "Incorrect credentials!" });
    }
}