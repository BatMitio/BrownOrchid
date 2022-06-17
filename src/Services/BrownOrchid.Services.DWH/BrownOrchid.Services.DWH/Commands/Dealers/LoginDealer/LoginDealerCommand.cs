﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BrownOrchid.Common.Application.Jwt.Interfaces;
using BrownOrchid.Common.Domain.Types;
using BrownOrchid.Services.DWH.Data.Repositories.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BrownOrchid.Services.DWH.Commands.Dealers.LoginDealer;

public class LoginDealerCommand : IRequest<ApiResponse<string>>
{
    public string Username { get; set; }
    public string Password { get; set; }

    public LoginDealerCommand()
    {
    }

    public LoginDealerCommand(string username, string password)
    {
        Username = username;
        Password = password;
    }
}

public class LoginDealerCommandHandler : IRequestHandler<LoginDealerCommand, ApiResponse<string>>
{
    private IDealerRepository _repository;
    private IConfiguration _configuration;

    private ITokenGenerator _tokenGenerator;

    //TODO: Set to an adequate value in production
    private const int ExpirationInMinutes = 3000;


    public LoginDealerCommandHandler(IDealerRepository repository, IConfiguration configuration, ITokenGenerator tokenGenerator)
    {
        _repository = repository;
        _configuration = configuration;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ApiResponse<string>> Handle(LoginDealerCommand request, CancellationToken cancellationToken)
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