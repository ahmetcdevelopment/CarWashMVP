using Application.Features.AdvertItems.Commands.Create;
using Application.Features.AdvertItems.Commands.Delete;
using Application.Features.AdvertItems.Commands.Update;
using Application.Features.AdvertItems.Queries.GetById;
using Application.Features.AdvertItems.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvertItemsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAdvertItemCommand createAdvertItemCommand)
    {
        CreatedAdvertItemResponse response = await Mediator.Send(createAdvertItemCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAdvertItemCommand updateAdvertItemCommand)
    {
        UpdatedAdvertItemResponse response = await Mediator.Send(updateAdvertItemCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedAdvertItemResponse response = await Mediator.Send(new DeleteAdvertItemCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdAdvertItemResponse response = await Mediator.Send(new GetByIdAdvertItemQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAdvertItemQuery getListAdvertItemQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAdvertItemListItemDto> response = await Mediator.Send(getListAdvertItemQuery);
        return Ok(response);
    }
}