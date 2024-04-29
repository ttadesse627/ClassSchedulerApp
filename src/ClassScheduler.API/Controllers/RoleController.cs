using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Contracts.ResponseDtos.RoleDtos;
using ClassScheduler.Application.Features.Roles;
using ClassScheduler.Application.Features.Roles.Commands;
using ClassScheduler.Application.Features.Roles.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.API.Controllers;
public class RoleController(ISender sender) : ApiController
{
    private readonly ISender _sender = sender;

    [HttpPost("Create")]
    public async Task<ActionResult<ServiceResponse<int>>> Create(CreateRoleCommand request)
    {
        return Ok(await _sender.Send(request));
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<RoleDto>>> GetAll()
    {
        return Ok(await _sender.Send(new GetRolesQuery()));
    }

    [HttpGet("GetDropdowns")]
    public async Task<ActionResult<ServiceResponse<int>>> GetDropdowns()
    {
        return Ok(await _sender.Send(new GetRolesQuery()));
    }

    [HttpPut("Update/{id}")]
    public async Task<ActionResult<ServiceResponse<int>>> UpdateRoles(string id, UpdateRoleCommand updateRoleCommand)
    {
        if (Guid.Parse(id) == updateRoleCommand.Id)
        {
            return Ok(await _sender.Send(updateRoleCommand));
        }

        return BadRequest("Query id and body id not matched");
    }

    [HttpGet("Get/{id}")]
    public async Task<ActionResult<ServiceResponse<RoleResponseDto>>> Get(string id)
    {
        Guid queryId = Guid.Parse(id);
        if (queryId != Guid.Empty)
        {
            return Ok(await _sender.Send(new GetRoleByIdQuery(queryId)));
        }
        return BadRequest("The Id should not be empty");
    }
}