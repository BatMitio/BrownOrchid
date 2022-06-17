using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
    //TODO: Set to an adequate value in production
    private const int ExpirationInMinutes = 3000;


    public LoginDealerCommandHandler(IDealerRepository repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }

    public async Task<ApiResponse<string>> Handle(LoginDealerCommand request, CancellationToken cancellationToken)
    {
        var user = await _repository.FindByUsername(request.Username);

        if (BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, 
                SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken(issuer: issuer,
                audience: audience,
                signingCredentials: credentials,
                expires: DateTime.UtcNow.AddMinutes(ExpirationInMinutes));
        
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);

            return new ApiResponse<string>(stringToken, "Successfully created a token");
        }

        return new ApiResponse<string>("An error occured when logging!", "", new[] { "The password you provided is incorrect!" });
    }
}