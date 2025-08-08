
using ClassScheduler.Application.Contracts.ResponseDtos.FacultyResponseDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Features.Faculties.Command.Create;
using ClassScheduler.Application.Features.Faculties.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.API.Controllers;
public class FacultyController(ISender sender): ApiController
{
    private readonly ISender _sender = sender;

    [HttpPost("Create")]
    public async Task<ActionResult<ServiceResponse<int>>> Create(CreateFacultyCommand command)
    {
        return Ok(await _sender.Send(command));
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<FacultiesResponseDto>>> GetAll()
    {
        return Ok(await _sender.Send(new GetAllFacultiesQuery()));
    }
    // [HttpDelete("Delete/{id}")]
    // public async Task<ActionResult<ServiceResponse<int>>> Delete(Guid id)
    // {
    //     return Ok(await _sender.Send(new DeleteCourseCommand(id)));
    // }

    [HttpGet("Get/{id}")]
    public async Task<ActionResult<ServiceResponse<FacultyResponseDto>>> Get(Guid id)
    {
        return Ok(await _sender.Send(new GetFacultyQuery(id)));
    }

    // [HttpPut("Update/{id}")]
    // public async Task<ActionResult<ServiceResponse<int>>> UpdateCourses(string id, UpdateCourseCommand updateCourseCommand)
    // {
    //     if (Guid.Parse(id) == updateCourseCommand.Id)
    //     {
    //         return Ok(await _sender.Send(updateCourseCommand));
    //     }

    //     return BadRequest("Query id and body id did not match!");
    // }

}