using AutoMapper;
using BrownOrchid.Common.Domain.Types;
using BrownOrchid.Services.Clients.Data.Entities;
using BrownOrchid.Services.Clients.Data.Repositories.Interfaces;
using MediatR;

namespace BrownOrchid.Services.Clients.Commands.RegisterClientCommand;

public class RegisterClientCommand : IRequest<ApiResponse>
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? CardNumber { get; set; }

    public RegisterClientCommand()
    {
        
    }
    
    public RegisterClientCommand(string? username, string? password, string? email, string? phoneNumber, string? cardNumber)
    {
        Username = username;
        Password = password;
        Email = email;
        PhoneNumber = phoneNumber;
        CardNumber = cardNumber;
    }
}

public class RegisterClientCommandHandler : IRequestHandler<RegisterClientCommand, ApiResponse>
{
    private IClientRepository _repository;
    private IMapper _mapper;

    public RegisterClientCommandHandler(IClientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ApiResponse> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
    {
        var client = _mapper.Map<Client>(request);
        client.RegistrationDate = DateTime.Now;
        client.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        client = await _repository.SaveAsync(client);
        if (client is not null)
            return new ApiResponse("Successful registration!");
        return new ApiResponse("Error!", new[] { "Registration error" });
    }
}