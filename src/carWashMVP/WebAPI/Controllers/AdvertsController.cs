using Application.Features.Adverts.Commands.Create;
using Application.Features.Adverts.Commands.Delete;
using Application.Features.Adverts.Commands.Update;
using Application.Features.Adverts.Queries.GetById;
using Application.Features.Adverts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvertsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAdvertCommand createAdvertCommand)
    {
        CreatedAdvertResponse response = await Mediator.Send(createAdvertCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAdvertCommand updateAdvertCommand)
    {
        UpdatedAdvertResponse response = await Mediator.Send(updateAdvertCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedAdvertResponse response = await Mediator.Send(new DeleteAdvertCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdAdvertResponse response = await Mediator.Send(new GetByIdAdvertQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAdvertQuery getListAdvertQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAdvertListItemDto> response = await Mediator.Send(getListAdvertQuery);
        return Ok(response);
    }
}