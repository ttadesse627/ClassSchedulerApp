using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Contracts.ResponseDtos.RoomResponseDtos;
using ClassScheduler.Application.Features.Courses.Query;
using ClassScheduler.Application.Features.Departments.Query;
using ClassScheduler.Application.Features.Rooms.Command.Create;
using ClassScheduler.Application.Features.Rooms.Command.Delete;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.API.Controllers;
public class RoomController(ISender mediator) : ApiController
{
    private readonly ISender _mediator = mediator;

    [HttpPost("Create")]
    public async Task<ActionResult<ServiceResponse<int>>> Create(CreateRoomCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<RoomResponseDto>>> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllRoomsQuery()));
    }
    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult<ServiceResponse<int>>> Delete(Guid id)
    {
        return Ok(await _mediator.Send(new DeleteRoomCommand(id)));
    }

    [HttpGet("Get/{id}")]
    public async Task<ActionResult<ServiceResponse<RoomResponseDto>>> Get(Guid id)
    {
        return Ok(await _mediator.Send(new GetByIdQuery(id)));
    }
}
