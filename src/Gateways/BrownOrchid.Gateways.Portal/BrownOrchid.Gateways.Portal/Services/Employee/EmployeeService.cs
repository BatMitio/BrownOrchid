using System.Net.Http.Json;
using System.Text.Json;
using BrownOrchid.Common.Domain.Types;
using BrownOrchid.Gateways.Portal.Data.Models.Employee;
using BrownOrchid.Gateways.Portal.Services.Employee.Interfaces;
using BrownOrchid.Gateways.Portal.Static;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace BrownOrchid.Gateways.Portal.Services.Employee;

public class EmployeeService : IEmployeeService
{
    private HttpClient _httpClient;

    public EmployeeService(IHttpClientFactory factory, IConfiguration configuration)
    {
        _httpClient = factory.CreateClient(configuration["Services:Employee:Client"]);
    }

    public async Task<ApiResponse<string>?> CheckPasswordAsync(string userName, string password)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, Endpoints.CheckEmployeePassword);
        var credentials = new CheckPasswordModel(userName, password);
        var json = JsonSerializer.Serialize(credentials);
        
        request.Content = new StringContent(json);
        request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
        var response = await _httpClient.SendAsync(request);

        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse<string>>();
        
        return apiResponse;
    }
}