using BrownOrchid.Services.App.Queries.QueryDiscounts;
using BrownOrchid.Services.App.Queries.QueryPosTerminals;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrownOrchid.Services.App.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PosTerminalController : ControllerBase
{
    private IMediator _mediator;

    public PosTerminalController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "Employee")]
    public async Task<IActionResult> All()
    {
        var query = new QueryPosTerminals();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}