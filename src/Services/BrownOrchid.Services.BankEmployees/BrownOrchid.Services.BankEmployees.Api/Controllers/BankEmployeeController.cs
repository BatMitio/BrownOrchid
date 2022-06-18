using BrownOrchid.Services.BankEmployees.Commands.LoginEmployee;
using BrownOrchid.Services.BankEmployees.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrownOrchid.Services.BankEmployees.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BankEmployeeController : ControllerBase
{
    private IMediator _mediator;

    public BankEmployeeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginBankEmployeeDto loginBankEmployeeDto)
    {
        var command = new LoginEmployeeCommand()
            { Username = loginBankEmployeeDto.Username, Password = loginBankEmployeeDto.Password };
        var result = await _mediator.Send(command);

        if (result.IsValid)
            return Ok(result);
        return BadRequest(result);
    }
}