using System.Security.Claims;
using BrownOrchid.Common.Domain.Types;
using BrownOrchid.Services.App.Commands.ApproveDiscountCommand;
using BrownOrchid.Services.App.Commands.CreateDiscountCommand;
using BrownOrchid.Services.App.DTOs;
using BrownOrchid.Services.App.Queries.QueryDiscounts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrownOrchid.Services.App.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DiscountController : ControllerBase
{
    private IMediator _mediator;

    public DiscountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "Dealer")]
    public async Task<IActionResult> Create(CreateDiscountDto createDiscountDto)
    {
        var dealerId = User.Claims.FirstOrDefault(c => c.Type == "id");
        if (dealerId is null)
            return BadRequest(new ApiResponse("Fail", new[] { "No id in jwt!" }));
        var command = new CreateDiscountCommand()
        {
            Amount = createDiscountDto.Amount,
            DealerId = dealerId.Value,
            StartDate = createDiscountDto.StartDate,
            EndDate = createDiscountDto.EndTime
        };

        var result = await _mediator.Send(command);
        if (result.IsValid)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "Employee")]
    public async Task<IActionResult> Approve(ApproveDiscountDto approveDiscountDto)
    {
        var employeeId = User.Claims.FirstOrDefault(c => c.Type == "id").Value;
        var command = new ApproveDiscountCommand()
            { DiscountId = approveDiscountDto.DiscountId, EmployeeId = employeeId };
        var result = await _mediator.Send(command);
        if (result.IsValid)
            return Ok(result);
        return BadRequest(result);
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "Employee")]
    public async Task<IActionResult> All()
    {
        var query = new QueryDiscounts();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet]
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "Employee")]
    public async Task<IActionResult> AllWaiting()
    {
        var query = new QueryWaitingDiscounts();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> AllActive()
    {
        var query = new QueryActiveDiscounts();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}