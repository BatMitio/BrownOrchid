using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using BrownOrchid.Common.Domain.Types;
using BrownOrchid.Gateways.Portal.Data.Models.Client;
using BrownOrchid.Gateways.Portal.Data.Models.Employee;
using BrownOrchid.Gateways.Portal.Providers;
using BrownOrchid.Gateways.Portal.Services.Client.Interfaces;
using BrownOrchid.Gateways.Portal.Static;
using BrownOrchid.Gateways.Portal.Views.Discounts;
using Microsoft.Extensions.Configuration;

namespace BrownOrchid.Gateways.Portal.Services.Client;

public class ClientService : IClientService
{
    private HttpClient _httpClient;
    private TokenAuthenticationStateProvider _authenticationStateProvider;

    public ClientService(IHttpClientFactory factory, IConfiguration configuration, TokenAuthenticationStateProvider authenticationStateProvider)
    {
        _authenticationStateProvider = authenticationStateProvider;
        _httpClient = factory.CreateClient(configuration["Services:Client:Client"]);
    }
    
    public async Task<ApiResponse?> RegisterClientAsync(string? dataModelUsername, string? dataModelPassword, string? dataModelEmail,
        string? dataModelPhoneNumber, string? dataModelCardNumber)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, Endpoints.CreateClient);
        var credentials = new ClientRegisterCredentials()
        {
            Username = dataModelUsername, Password = dataModelPassword, Email = dataModelEmail,
            PhoneNumber = dataModelPhoneNumber, CardNumber = dataModelCardNumber
        };
        var json = JsonSerializer.Serialize(credentials);
        
        request.Content = new StringContent(json);
        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        var response = await _httpClient.SendAsync(request);
        
        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();

        return apiResponse;
    }

    public async Task<ApiResponse<string?>> LoginClientAsync(string? userName, string? password)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, Endpoints.CheckClientPassword);
        var credentials = new CheckPasswordModel(userName, password);
        var json = JsonSerializer.Serialize(credentials);
        
        request.Content = new StringContent(json);
        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        var response = await _httpClient.SendAsync(request);

        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<string?>>();
        
        return apiResponse;
    }

    
}