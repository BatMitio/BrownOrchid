using System.Security.Claims;
using BrownOrchid.Common.Application.Jwt.Interfaces;
using BrownOrchid.Common.Domain.Types;
using BrownOrchid.Services.App.Data.Repositories.Interfaces;
using MediatR;

namespace BrownOrchid.Services.App.Commands.LoginDealerCommand;

public class LoginDealerCommand : IRequest<ApiResponse<string?>>
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class LoginDealerCommandHandler : IRequestHandler<LoginDealerCommand, ApiResponse<string?>>
{
    private IDealerRepository _repository;
    private ITokenGenerator _tokenGenerator;

    public LoginDealerCommandHandler(IDealerRepository repository, ITokenGenerator tokenGenerator)
    {
        _repository = repository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<ApiResponse<string?>> Handle(LoginDealerCommand request, CancellationToken cancellationToken)
    {
        var dealer = await _repository.FindByUsernameAsync(request.Username);
        if (BCrypt.Net.BCrypt.Verify(request.Password, dealer!.PasswordHash))
        {
            return new ApiResponse<string?>(_tokenGenerator.GenerateToken(new[]
            {
                new Claim("role", "dealer"),
                new Claim("id", dealer.Id)
            }));
        }

        return new ApiResponse<string?>(null, "Fail!", new[] { "Invalid credentials!" });
    }
}