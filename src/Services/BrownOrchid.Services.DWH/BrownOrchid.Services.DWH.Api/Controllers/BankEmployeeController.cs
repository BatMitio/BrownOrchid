using AutoMapper;
using BrownOrchid.Services.DWH.Commands.BankEmployees.CreateBankEmployee;
using BrownOrchid.Services.DWH.Commands.BankEmployees.LoginBankEmployee;
using BrownOrchid.Services.DWH.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrownOrchid.Services.DWH.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BankEmployeeController : ControllerBase
{
    private IMapper _mapper;
    private IMediator _mediator;

    public BankEmployeeController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterBankEmployeeDto registerBankEmployeeDto)
    {
        var command = _mapper.Map<CreateBankEmployeeCommand>(registerBankEmployeeDto);
        var result = await _mediator.Send(command);

        if (result.IsValid)
            return Ok(result);
        return BadRequest(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginBankEmployeeDto loginBankEmployeeDto)
    {
        var command = _mapper.Map<LoginBankEmployeeCommand>(loginBankEmployeeDto);
        var result = await _mediator.Send(command);

        if (result.IsValid)
            return Ok(result);
        return BadRequest(result);
    }
}