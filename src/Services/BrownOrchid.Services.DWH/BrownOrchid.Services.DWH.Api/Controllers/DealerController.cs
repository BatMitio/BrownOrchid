using AutoMapper;
using BrownOrchid.Services.DWH.Commands.Dealers.CreateDealer;
using BrownOrchid.Services.DWH.Commands.Dealers.LoginDealer;
using BrownOrchid.Services.DWH.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrownOrchid.Services.DWH.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DealerController : ControllerBase
{
    private IMapper _mapper;
    private IMediator _mediator;

    public DealerController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterDealerDto registerDealerDto)
    {
        var registerCommand = _mapper.Map<CreateDealerCommand>(registerDealerDto);
        var result = await _mediator.Send(registerCommand);

        if (result.IsValid)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDealerDto loginDealerDto)
    {
        var loginCommand = _mapper.Map<LoginDealerCommand>(loginDealerDto);
        var result = await _mediator.Send(loginCommand);

        if (result.IsValid)
            return Ok(result);
        return BadRequest(result);
    }
}