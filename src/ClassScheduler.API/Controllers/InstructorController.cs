using ClassScheduler.Application.Contracts.RequestDtos.InstructorRequestDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.InstructorResponseDts;
using ClassScheduler.Application.Features.Instructors.Command.Create;
using ClassScheduler.Application.Features.Instructors.Command.Delete;
using ClassScheduler.Application.Features.Instructors.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.API.Controllers;
public class InstructorController : ApiController
{
    private readonly ISender _sender;
    public InstructorController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("Create")]
    public async Task<ActionResult> Create(InstructorRequestDto requestDto)
    {
        return Ok(await _sender.Send(new CreateInstructorCommand(requestDto)));
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<InstructorResponseDto>>> Get()
    {
        return Ok(await _sender.Send(new GetListQuery()));
    }

    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        return Ok(await _sender.Send(new DeleteInstructorCommand(id)));
    }

}