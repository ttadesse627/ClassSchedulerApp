using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using MediatR;

namespace ClassScheduler.Application.Features.Courses.Command.Create;
public record CreateCourseRequest
{
    public required string Name { get; set; }
    public required string CourseCode { get; set; }
    public int CreditHours { get; set; }
    public int ECTS { get; set; }
}

