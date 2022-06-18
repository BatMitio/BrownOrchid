using BrownOrchid.Common.Domain.Types;

namespace BrownOrchid.Gateways.Portal.Services.Employee.Interfaces;

public interface IEmployeeService
{
    Task<ApiResponse<string>?> CheckPasswordAsync(string userName, string password);
}