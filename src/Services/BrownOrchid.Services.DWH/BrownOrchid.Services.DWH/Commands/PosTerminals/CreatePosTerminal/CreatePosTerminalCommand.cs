using BrownOrchid.Common.Domain.Types;
using BrownOrchid.Common.Domain.Entities;
using BrownOrchid.Services.DWH.Data.Repositories.Interfaces;
using MediatR;

namespace BrownOrchid.Services.DWH.Commands.PosTerminals.CreatePosTerminal;

public class CreatePosTerminalCommand : IRequest<ApiResponse>
{
    public string TerminalId { get; set; }
    public string DealerUsername { get; set; }
}

public class CreatePosTerminalCommandHandler : IRequestHandler<CreatePosTerminalCommand, ApiResponse>
{
    private IPosTerminalRepository _repository;
    private IDealerRepository _dealerRepository;

    public CreatePosTerminalCommandHandler(IPosTerminalRepository repository, IDealerRepository dealerRepository)
    {
        _repository = repository;
        _dealerRepository = dealerRepository;
    }

    public async Task<ApiResponse> Handle(CreatePosTerminalCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.SaveAsync(new PosTerminal());
        
        if (request is null)
            return new ApiResponse("An error occured saving the pos terminal!", new[] { "The terminal could not be saved!" });
        
        result.Dealer = await _dealerRepository.FindByUsernameAsync(request.DealerUsername);
        await _repository.UpdateAsync(result);
        
        return new ApiResponse("Successfully saved the terminal!");
    }
}