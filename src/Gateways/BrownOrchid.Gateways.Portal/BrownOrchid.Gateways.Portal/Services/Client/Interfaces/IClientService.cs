using BrownOrchid.Common.Domain.Types;
using BrownOrchid.Gateways.Portal.Views.Discounts;

namespace BrownOrchid.Gateways.Portal.Services.Client.Interfaces;

public interface IClientService
{
    public Task<ApiResponse?> RegisterClientAsync(string? dataModelUsername, string? dataModelPassword, string? dataModelEmail,
        string? dataModelPhoneNumber, string? dataModelCardNumber);

    Task<ApiResponse<string?>> LoginClientAsync(string? dataModelUsername, string? dataModelPassword);

    
}