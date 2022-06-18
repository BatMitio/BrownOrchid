using AutoMapper;
using BrownOrchid.Common.Domain.Types;
using BrownOrchid.Common.Domain.Entities;
using BrownOrchid.Services.DWH.Data.Repositories.Interfaces;
using MediatR;

namespace BrownOrchid.Services.DWH.Commands.BankEmployees.CreateBankEmployee;

public class CreateBankEmployeeCommand : IRequest<ApiResponse>
{
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public CreateBankEmployeeCommand()
    {
    }

    public CreateBankEmployeeCommand(string email, string username, string password)
    {
        Email = email;
        Username = username;
        Password = password;
    }
}

public class CreateBankEmployeeCommandHandler : IRequestHandler<CreateBankEmployeeCommand, ApiResponse>
{
    private IMapper _mapper;
    private IBankEmployeeRepository _repository;

    public CreateBankEmployeeCommandHandler(IMapper mapper, IBankEmployeeRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<ApiResponse> Handle(CreateBankEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = _mapper.Map<BankEmployee>(request);
        employee.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        var result = await _repository.SaveAsync(employee);
        if (result is null)
            return new ApiResponse("An error occured while saving a bank employee account!",
                new[]
                {
                    "The entity could not be saved!"
                });
        return new ApiResponse("The bank employee was saved successfully!");
    }
}