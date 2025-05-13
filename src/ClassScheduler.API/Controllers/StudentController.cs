using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Contracts.ResponseDtos.StudentResponseDts;
using ClassScheduler.Application.Features.Students.Command.Create;
using ClassScheduler.Application.Features.Students.Command.Delete;
using ClassScheduler.Application.Features.Students.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.API.Controllers;

public class StudentController : ApiController
{
    private readonly ISender _sender;

    public StudentController(ISender sender)
    {
        _sender = sender;
    }


    // Students endpoints
    [HttpPost(Name = "CreateStudent")]
    public async Task<ActionResult<ServiceResponse<int>>> Create(CreateStudentCommand command)
    {
        var response = await _sender.Send(command);
        return Ok(response);
    }

    [HttpGet(Name = "GetStudents")]
    public async Task<ActionResult<List<StudentResponseDto>>> Get()
    {
        var response = await _sender.Send(new GetStudentsQuery());
        return Ok(response);
    }

    [HttpGet("Get/{id}")]
    public async Task<ActionResult<StudentResponseDto>> Get(string id)
    {
        object response = null!;
        if (!string.IsNullOrEmpty(id))
        {
            response = await _sender.Send(new GetStudentQuery(Guid.Parse(id)));
        }
        else
        {
            return BadRequest("The student Id is missing!");
        }

        return Ok(response);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult<StudentResponseDto>> Delete(string id)
    {
        object response;
        if (!string.IsNullOrEmpty(id))
        {
            response = await _sender.Send(new DeleteStudentCommand(Guid.Parse(id)));
        }
        else
        {
            return BadRequest("The student Id is missing!");
        }

        return Ok(response);
    }
}