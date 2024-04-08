using ClassScheduler.Application.Contracts.RequestDtos.RoleRequestDtos;
using ClassScheduler.Application.Contracts.RequestDtos.UserRequestDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Contracts.ResponseDtos.RoleDtos;
using ClassScheduler.Application.Features.Roles;
using ClassScheduler.Application.Features.Roles.Query;
using ClassScheduler.Application.Features.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.API.Controllers;
public class RoleController(ISender sender) : ApiController
{
    private readonly ISender _sender = sender;

    [HttpPost("Create")]
    public async Task<ActionResult<ServiceResponse<int>>> Create(CreateRoleRequest request)
    {
        return Ok(await _sender.Send(new CreateRoleCommand(request)));
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
}