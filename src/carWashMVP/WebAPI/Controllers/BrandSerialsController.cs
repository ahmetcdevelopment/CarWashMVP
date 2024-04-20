using Application.Features.BrandSerials.Commands.Create;
using Application.Features.BrandSerials.Commands.Delete;
using Application.Features.BrandSerials.Commands.Update;
using Application.Features.BrandSerials.Queries.GetById;
using Application.Features.BrandSerials.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandSerialsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateBrandSerialCommand createBrandSerialCommand)
    {
        CreatedBrandSerialResponse response = await Mediator.Send(createBrandSerialCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBrandSerialCommand updateBrandSerialCommand)
    {
        UpdatedBrandSerialResponse response = await Mediator.Send(updateBrandSerialCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedBrandSerialResponse response = await Mediator.Send(new DeleteBrandSerialCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdBrandSerialResponse response = await Mediator.Send(new GetByIdBrandSerialQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListBrandSerialQuery getListBrandSerialQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListBrandSerialListItemDto> response = await Mediator.Send(getListBrandSerialQuery);
        return Ok(response);
    }
}