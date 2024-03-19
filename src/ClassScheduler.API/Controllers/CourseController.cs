using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Contracts.ResponseDtos.CourseResponseDtos;
using ClassScheduler.Application.Features.Courses.Command.Create;
using ClassScheduler.Application.Features.Courses.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.API.Controllers;
public class CourseController(ISender mediator) : ApiController
{
    private readonly ISender _mediator = mediator;

    [HttpPost("Create")]
    public async Task<ActionResult<ServiceResponse<int>>> Create(CreateCourseCommand command)
    {
        return Ok(await _mediator.Send(command));
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<CourseResponseDto>>> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllCoursesQuery()));
    }
}
