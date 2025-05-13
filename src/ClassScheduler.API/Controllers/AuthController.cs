using ClassScheduler.Application.Contracts.ResponseDtos.AuthResponseDtos;
using ClassScheduler.Application.Features.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.API.Controllers;
public class AuthController(ISender sender) : ApiController
{
    private readonly ISender _sender = sender;

    [HttpPost("Login")]
    public async Task<ActionResult<AuthResponseDto>> Login(AuthCommand command)
    {
        var response = await _sender.Send(command);
        if (response is not null)
        {
            return Ok(response);
        }
        return Forbid("Invalid Credentials");
    }

}