using AutoMapper;
using BrownOrchid.Services.Clients.Commands.RegisterClientCommand;
using BrownOrchid.Services.Clients.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BrownOrchid.Services.Clients.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ClientController : ControllerBase
{
    private IMapper _mapper;
    private IMediator _mediator;

    public ClientController(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Register(ClientRegisterDto clientRegisterDto)
    {
        var command = _mapper.Map<RegisterClientCommand>(clientRegisterDto);
        var result = await _mediator.Send(command);

        if (result.IsValid)
            return Ok(result);
        return BadRequest(result);
    }
}