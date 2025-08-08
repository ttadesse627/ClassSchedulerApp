
using ClassScheduler.Application.Contracts.ResponseDtos.CampusResponseDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Features.Campuses.Command.Create;
using ClassScheduler.Application.Features.Campuses.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.API.Controllers;
public class CampusController(ISender sender): ApiController
{
    private readonly ISender _sender = sender;

    [HttpPost("Create")]
    public async Task<ActionResult<ServiceResponse<int>>> Create(CreateCampusCommand command)
    {
        return Ok(await _sender.Send(command));
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<List<CampusResponseDto>>> GetAll()
    {
        return Ok(await _sender.Send(new GetAllCampusesQuery()));
    }
    // [HttpDelete("Delete/{id}")]
    // public async Task<ActionResult<ServiceResponse<int>>> Delete(Guid id)
    // {
    //     return Ok(await _sender.Send(new DeleteCourseCommand(id)));
    // }

    [HttpGet("Get/{id}")]
    public async Task<ActionResult<ServiceResponse<CampusResponseDto>>> Get(Guid id)
    {
        return Ok(await _sender.Send(new GetCampusQuery(id)));
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