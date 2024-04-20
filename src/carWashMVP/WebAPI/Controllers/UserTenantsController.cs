using Application.Features.UserTenants.Commands.Create;
using Application.Features.UserTenants.Commands.Delete;
using Application.Features.UserTenants.Commands.Update;
using Application.Features.UserTenants.Queries.GetById;
using Application.Features.UserTenants.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserTenantsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserTenantCommand createUserTenantCommand)
    {
        CreatedUserTenantResponse response = await Mediator.Send(createUserTenantCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserTenantCommand updateUserTenantCommand)
    {
        UpdatedUserTenantResponse response = await Mediator.Send(updateUserTenantCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedUserTenantResponse response = await Mediator.Send(new DeleteUserTenantCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdUserTenantResponse response = await Mediator.Send(new GetByIdUserTenantQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserTenantQuery getListUserTenantQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserTenantListItemDto> response = await Mediator.Send(getListUserTenantQuery);
        return Ok(response);
    }
}