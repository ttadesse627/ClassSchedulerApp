using MediatR;
using Microsoft.AspNetCore.Mvc;
using ClassScheduler.Application.Contracts.ResponseDtos.ExamResponseDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Features.Faculties.Query;
using ClassScheduler.Application.Features.Exams.Command.Create;
using ClassScheduler.Application.Features.Exams.Query;

namespace ClassScheduler.API.Controllers;
public class ExamController(ISender sender): ApiController
{
    private readonly ISender _sender = sender;

    [HttpPost("Create")]
    public async Task<ActionResult<ServiceResponse<int>>> Create(CreateExamCommand command)
    {
        return Ok(await _sender.Send(command));
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<ExamResponseDto>>> GetAll()
    {
        return Ok(await _sender.Send(new GetAllFacultiesQuery()));
    }
    // [HttpDelete("Delete/{id}")]
    // public async Task<ActionResult<ServiceResponse<int>>> Delete(Guid id)
    // {
    //     return Ok(await _sender.Send(new DeleteCourseCommand(id)));
    // }

    [HttpGet("Get/{id}")]
    public async Task<ActionResult<ServiceResponse<ExamResponseDto>>> Get(Guid id)
    {
        return Ok(await _sender.Send(new GetExamQuery(id)));
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