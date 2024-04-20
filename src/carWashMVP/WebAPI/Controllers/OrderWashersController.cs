using Application.Features.OrderWashers.Commands.Create;
using Application.Features.OrderWashers.Commands.Delete;
using Application.Features.OrderWashers.Commands.Update;
using Application.Features.OrderWashers.Queries.GetById;
using Application.Features.OrderWashers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderWashersController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOrderWasherCommand createOrderWasherCommand)
    {
        CreatedOrderWasherResponse response = await Mediator.Send(createOrderWasherCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOrderWasherCommand updateOrderWasherCommand)
    {
        UpdatedOrderWasherResponse response = await Mediator.Send(updateOrderWasherCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedOrderWasherResponse response = await Mediator.Send(new DeleteOrderWasherCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdOrderWasherResponse response = await Mediator.Send(new GetByIdOrderWasherQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListOrderWasherQuery getListOrderWasherQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListOrderWasherListItemDto> response = await Mediator.Send(getListOrderWasherQuery);
        return Ok(response);
    }
}