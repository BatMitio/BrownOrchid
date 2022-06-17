using AutoMapper;
using BrownOrchid.Common.Domain.Types;
using BrownOrchid.Services.DWH.Data.Entities;
using BrownOrchid.Services.DWH.Data.Repositories.Interfaces;
using MediatR;

namespace BrownOrchid.Services.DWH.Commands.Dealers.CreateDealer;

public class CreateDealerCommand : IRequest<ApiResponse>
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public CreateDealerCommand()
    {
    }

    public CreateDealerCommand(string username, string password, string email, string phoneNumber)
    {
        Username = username;
        Password = password;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}

public class CreateDealerCommandHandler : IRequestHandler<CreateDealerCommand, ApiResponse>
{
    private IMapper _mapper;
    private IDealerRepository _repository;

    public CreateDealerCommandHandler(IMapper mapper, IDealerRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<ApiResponse> Handle(CreateDealerCommand request, CancellationToken cancellationToken)
    {
        var dealer = _mapper.Map<Dealer>(request);
        
        if (dealer is null)
            return new ApiResponse("An error occured while trying to save dealer in the database!", new[] { "Unknown" });

        dealer.RegistrationDate = DateTime.Now;
        dealer.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        await _repository.SaveAsync(dealer);

        return new ApiResponse("Dealer was successfully created!");
    }
}