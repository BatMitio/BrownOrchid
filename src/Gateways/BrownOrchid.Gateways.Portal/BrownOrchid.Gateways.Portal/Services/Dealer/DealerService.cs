using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using BrownOrchid.Common.Domain.Types;
using BrownOrchid.Gateways.Portal.Data.Models.Discount;
using BrownOrchid.Gateways.Portal.Data.Models.Employee;
using BrownOrchid.Gateways.Portal.Providers;
using BrownOrchid.Gateways.Portal.Services.Dealer.Interfaces;
using BrownOrchid.Gateways.Portal.Static;
using BrownOrchid.Gateways.Portal.Views.Discounts;
using BrownOrchid.Services.App.Data.Views;
using Microsoft.Extensions.Configuration;

namespace BrownOrchid.Gateways.Portal.Services.Dealer;

public class DealerService : IDealerService
{
    private HttpClient _httpClient;
    private TokenAuthenticationStateProvider _authenticationStateProvider;

    public DealerService(IHttpClientFactory factory, IConfiguration configuration,
        TokenAuthenticationStateProvider authenticationStateProvider)
    {
        _authenticationStateProvider = authenticationStateProvider;
        _httpClient = factory.CreateClient(configuration["Services:App:Client"]);
    }

    public async Task<ApiResponse<string?>> LoginDealerAsync(string? username, string? password)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, Endpoints.CheckDealerPassword);
        var credentials = new CheckPasswordModel(username, password);
        var json = JsonSerializer.Serialize(credentials);

        request.Content = new StringContent(json);
        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        var response = await _httpClient.SendAsync(request);

        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<string?>>();

        return apiResponse;
    }

    public async Task<List<DealerView>> GetAllDealersAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, Endpoints.GetAllDealers);
        request.Headers.Add("Authorization", "Bearer " + await _authenticationStateProvider.GetTokenAsync());
        var response = await _httpClient.SendAsync(request);
        var apiResponse = await response.Content.ReadFromJsonAsync<List<DealerView>>();
        return apiResponse;
    }

    public async Task<List<DiscountView>> GetAvailableDiscounts()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, Endpoints.GetActiveDiscounts);
        request.Headers.Add("Authorization", "Bearer " + await _authenticationStateProvider.GetTokenAsync());
        var response = await _httpClient.SendAsync(request);
        var apiResponse = await response.Content.ReadFromJsonAsync<List<DiscountView>>();
        return apiResponse;
    }

    public async Task<List<DiscountView>> GetAllDiscountsAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, Endpoints.AllDiscounts);
        request.Headers.Add("Authorization", "Bearer " + await _authenticationStateProvider.GetTokenAsync());
        var response = await _httpClient.SendAsync(request);
        var apiResponse = await response.Content.ReadFromJsonAsync<List<DiscountView>>();
        return apiResponse;
    }

    public async Task<List<DiscountView>> GetAllWaitingDiscounts()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, Endpoints.AllWaitingDiscounts);
        request.Headers.Add("Authorization", "Bearer " + await _authenticationStateProvider.GetTokenAsync());
        var response = await _httpClient.SendAsync(request);
        var apiResponse = await response.Content.ReadFromJsonAsync<List<DiscountView>>();
        return apiResponse;
    }

    public async Task<List<PosTerminalView>> GetAllTerminalsAsync()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, Endpoints.AllPosTerminals);
        request.Headers.Add("Authorization", "Bearer " + await _authenticationStateProvider.GetTokenAsync());
        var response = await _httpClient.SendAsync(request);
        var apiResponse = await response.Content.ReadFromJsonAsync<List<PosTerminalView>>();
        return apiResponse;
    }

    public async Task<ApiResponse<string?>> CreateDiscount(int amount, DateTime startDate, DateTime endDate)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, Endpoints.CreateDiscount);
        var payload = new DiscountModel(amount, endDate, endDate);
        var json = JsonSerializer.Serialize(payload);
        request.Headers.Add("Authorization", "Bearer " + await _authenticationStateProvider.GetTokenAsync());
        request.Content = new StringContent(json);
        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        var response = await _httpClient.SendAsync(request);
        return await response.Content.ReadFromJsonAsync<ApiResponse<string?>>();
    }
}