using ClassScheduler.Application.Contracts.RequestDtos.UserRequestDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Features.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.API.Controllers;
public class UserController(ISender sender) : ApiController
{
    private readonly ISender _sender = sender;

    [HttpPost("Create")]
    public async Task<ActionResult<ServiceResponse<int>>> Create(CreateUserRequest request)
    {
        return Ok(await _sender.Send(new CreateUserCommand(request)));
    }
}