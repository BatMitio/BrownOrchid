using BrownOrchid.Common.Application.Jwt.Interfaces;
using BrownOrchid.Common.Domain.Types;
using BrownOrchid.Services.DWH.Data.Repositories.Interfaces;
using MediatR;

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
    private ITokenGenerator _tokenGenerator;

    public LoginDealerCommandHandler(IDealerRepository repository, ITokenGenerator tokenGenerator)
    {
        _repository = repository;
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