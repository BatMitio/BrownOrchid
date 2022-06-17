using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BrownOrchid.Common.Application.Jwt.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BrownOrchid.Common.Application.Jwt;

public class TokenGenerator : ITokenGenerator
{
    private IConfiguration _configuration;
    //TODO: Set to an adequate value in production
    private const int ExpirationInMinutes = 3000;

    public TokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(Claim[] claims = null)
    {
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, 
            SecurityAlgorithms.HmacSha256);
            
        var token = new JwtSecurityToken(issuer: issuer,
            audience: audience,
            signingCredentials: credentials,
            expires: DateTime.UtcNow.AddMinutes(ExpirationInMinutes),
            claims: claims);
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var stringToken = tokenHandler.WriteToken(token);
        return stringToken;
    }
}