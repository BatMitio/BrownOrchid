using BrownOrchid.Common.Domain.Types;
using BrownOrchid.Gateways.Portal.Services.Client.Interfaces;

namespace BrownOrchid.Gateways.Portal.Services.Client;

public class ClientService : IClientService
{
    public Task<ApiResponse?> RegisterClientAsync(string? dataModelUsername, string? dataModelPassword, string? dataModelEmail,
        string? dataModelPhoneNumber, string? dataModelCardNumber)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<string?>> LoginClientAsync(string? dataModelUsername, string? dataModelPassword)
    {
        throw new NotImplementedException();
    }
}