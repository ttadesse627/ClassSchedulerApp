using ClassScheduler.Application.Contracts.ResponseDtos.AuthResponseDtos;
using ClassScheduler.Application.Features.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.API.Controllers;
public class AuthController(ISender sender) : ApiController
{
    private readonly ISender _sender = sender;
    public async Task<ActionResult<AuthResponseDto>> Login(AuthCommand command)
    {
        return Ok(await _sender.Send(command));
    }

}