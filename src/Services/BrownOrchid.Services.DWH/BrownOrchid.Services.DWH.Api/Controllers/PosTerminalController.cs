using BrownOrchid.Services.DWH.Commands.PosTerminals.CreatePosTerminal;
using BrownOrchid.Services.DWH.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrownOrchid.Services.DWH.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PosTerminalController : ControllerBase
{
    private IMediator _mediator;

    public PosTerminalController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePosTerminalDto createPosTerminalDto)
    {
        var command = new CreatePosTerminalCommand() { DealerUsername = createPosTerminalDto.DealerUsername };
        var result = await _mediator.Send(command);

        if (result.IsValid)
            return Ok(result);
        return BadRequest(result);
    }
}