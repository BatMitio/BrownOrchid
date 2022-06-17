using System.Security.Claims;

namespace BrownOrchid.Common.Application.Jwt.Interfaces;

public interface ITokenGenerator
{
    public string GenerateToken(Claim[] claims = null);
}