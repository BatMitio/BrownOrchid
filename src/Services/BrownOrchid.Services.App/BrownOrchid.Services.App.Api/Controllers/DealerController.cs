using BrownOrchid.Services.App.Commands.LoginDealerCommand;
using BrownOrchid.Services.App.DTOs;
using BrownOrchid.Services.App.Queries.QueryDealers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrownOrchid.Services.App.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DealerController : ControllerBase
{
    private IMediator _mediator;

    public DealerController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDealerDto loginDealerDto)
    {
        var command = new LoginDealerCommand()
            { Username = loginDealerDto.Username, Password = loginDealerDto.Password };
        var result = await _mediator.Send(command);

        if (result.IsValid)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "Employee")]
    public async Task<IActionResult> All()
    {
        var query = new QueryDealers();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    
}