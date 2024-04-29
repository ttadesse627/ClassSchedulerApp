using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Contracts.ResponseDtos.ScheduleResponseDtos;
using ClassScheduler.Application.Features.Scheduler.Commands;
using ClassScheduler.Application.Features.Scheduler.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.API.Controllers;
public class ScheduleController : ApiController
{
    private readonly ISender _sender;
    public ScheduleController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("GenerateSchedule")]
    public async Task<ActionResult<ServiceResponse<int>>> Get()
    {
        return Ok(await _sender.Send(new GenerateScheduleCommand()));
    }

    [HttpGet("GetSchedules/{departmentId}")]
    public async Task<ActionResult<List<DepartmentClassesDto>>> Get(string departmentId)
    {
        if (!string.IsNullOrEmpty(departmentId.Trim()) && Guid.Parse(departmentId) != Guid.Empty)
        {
            return Ok(await _sender.Send(new GetScheduleQuery(Guid.Parse(departmentId))));
        }
        return BadRequest("Department Id is required");
    }

}