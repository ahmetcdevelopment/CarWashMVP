using Application.Features.AdvertSettings.Commands.Create;
using Application.Features.AdvertSettings.Commands.Delete;
using Application.Features.AdvertSettings.Commands.Update;
using Application.Features.AdvertSettings.Queries.GetById;
using Application.Features.AdvertSettings.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdvertSettingsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAdvertSettingCommand createAdvertSettingCommand)
    {
        CreatedAdvertSettingResponse response = await Mediator.Send(createAdvertSettingCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAdvertSettingCommand updateAdvertSettingCommand)
    {
        UpdatedAdvertSettingResponse response = await Mediator.Send(updateAdvertSettingCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedAdvertSettingResponse response = await Mediator.Send(new DeleteAdvertSettingCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdAdvertSettingResponse response = await Mediator.Send(new GetByIdAdvertSettingQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAdvertSettingQuery getListAdvertSettingQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAdvertSettingListItemDto> response = await Mediator.Send(getListAdvertSettingQuery);
        return Ok(response);
    }
}