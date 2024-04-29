using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Contracts.ResponseDtos.CourseResponseDtos;
using ClassScheduler.Application.Features.Courses.Command.Create;
using ClassScheduler.Application.Features.Courses.Delete.Create;
using ClassScheduler.Application.Features.Courses.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.API.Controllers;
public class CourseController(ISender mediator) : ApiController
{
    private readonly ISender _sender = mediator;

    [HttpPost("Create")]
    public async Task<ActionResult<ServiceResponse<int>>> Create(CreateCourseCommand command)
    {
        return Ok(await _sender.Send(command));
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<CourseResponseDto>>> GetAll()
    {
        return Ok(await _sender.Send(new GetAllCoursesQuery()));
    }
    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult<ServiceResponse<int>>> Delete(Guid id)
    {
        return Ok(await _sender.Send(new DeleteCourseCommand(id)));
    }

    [HttpDelete("Get/{id}")]
    public async Task<ActionResult<ServiceResponse<CourseResponseDto>>> Get(Guid id)
    {
        return Ok(await _sender.Send(new GetByIdQuery(id)));
    }

    [HttpPut("Update/{id}")]
    public async Task<ActionResult<ServiceResponse<int>>> UpdateCourses(string id, UpdateCourseCommand updateCourseCommand)
    {
        if (Guid.Parse(id) == updateCourseCommand.Id)
        {
            return Ok(await _sender.Send(updateCourseCommand));
        }

        return BadRequest("Query id and body id did not match!");
    }
}
