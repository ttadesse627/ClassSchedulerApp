using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClassScheduler.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public abstract class ApiController : ControllerBase
{
    private readonly ISender _sender = null!;

    protected ISender Sender => _sender ?? HttpContext.RequestServices.GetRequiredService<ISender>();
}