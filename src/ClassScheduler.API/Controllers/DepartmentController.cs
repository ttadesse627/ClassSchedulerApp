using ClassScheduler.Application.Contracts.RequestDtos.DepartmentRequestDtos;
using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Contracts.ResponseDtos.DepartmentResponseDtos;
using ClassScheduler.Application.Features.Departments.Command.Create;
using ClassScheduler.Application.Features.Departments.Command.Delete;
using ClassScheduler.Application.Features.Departments.Command.Update;
using ClassScheduler.Application.Features.Departments.Query;
using ClassScheduler.Domain.Model.Enums;
using ClassScheduler.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HasPermission(PermissionEnum.WriteMember)]
    [HttpPost(Name = "Create")]
    public async Task<ActionResult<ServiceResponse<DepartmentResponseDto>>> Create(DepartmentRequestDto departmentRequest)
    {
        var response = await _sender.Send(new CreateDepartmentCommand(departmentRequest));
        return Ok(response);
    }

    [HttpGet(Name = "GetAll")]
    public async Task<ActionResult<ServiceResponse<List<DepartmentResponseDto>>>> Get()
    {
        var response = await _sender.Send(new GetAllDepartmentsQuery());
        return Ok(response);
    }

    [HttpGet("Get/{id}")]
    public async Task<ActionResult<DepartmentResponseDto>> Get(string id)
    {
        object response;
        if (!string.IsNullOrEmpty(id.Trim()))
        {
            response = await _sender.Send(new GetDepartmentQuery(Guid.Parse(id)));
        }
        else
        {
            return BadRequest("The department id is missing!");
        }

        return Ok(response);
    }

    [HttpDelete("Delete/{id}")]
    public async Task<ActionResult<ServiceResponse<int>>> Delete(string id)
    {
        object response;
        if (!string.IsNullOrEmpty(id))
        {
            response = await _sender.Send(new DeleteDepartmentCommand(Guid.Parse(id)));
        }
        else
        {
            return BadRequest("The department id is missing!");
        }

        return Ok(response);
    }

    [HttpPut("Edit/{id}")]
    public async Task<ActionResult<ServiceResponse<string>>> Edit(string id, EditDepartmentRequestDto editRequest)
    {
        ServiceResponse<string>? response;
        if (!string.IsNullOrEmpty(id))
        {
            response = await _sender.Send(new EditDepartmentCommand(editRequest));
            if (!response.Success)
            {
                return BadRequest(response);
            }
        }
        else
        {
            return BadRequest("The department id is missing!");
        }

        return Ok(response);
    }
}