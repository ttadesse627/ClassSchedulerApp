using ClassScheduler.Application.Contracts.ResponseDtos.ScheduleResponseDtos;
using ClassScheduler.Application.Interfaces.Persistence;
using MediatR;

namespace ClassScheduler.Application.Features.Scheduler.Query;
public record GetScheduleQuery(Guid DepartmentId) : IRequest<List<DepartmentClassesDto>> { }
public class GetScheduleQueryHandler(IClassRepository classRepository) : IRequestHandler<GetScheduleQuery, List<DepartmentClassesDto>>
{
    private readonly IClassRepository _classRepository = classRepository;

    public async Task<List<DepartmentClassesDto>> Handle(GetScheduleQuery query, CancellationToken cancellationToken)
    {
        List<DepartmentClassesDto> departmentClassesDtos = [];

        var deptClasses = await _classRepository.GetByDepartmentAsync(query.DepartmentId);
        foreach (var deptCls in deptClasses.GroupBy(cl => cl.Department))
        {
            departmentClassesDtos.Add(new DepartmentClassesDto
            {
                Id = deptCls.Key.Id,
                Name = deptCls.Key.Name,
                ShortName = deptCls.Key.ShortName,
                DayGroups = deptCls.GroupBy(cl => cl.TimePeriod.Day).Select(dg => new DayGroupDto
                {
                    Day = dg.Key,
                    Classes = dg.Select(cls => new ClassDto
                    {
                        Id = cls.Id,
                        Course = new CourseDto
                        {
                            Id = cls.Course.Id,
                            Name = cls.Course.Name,
                            CourseCode = cls.Course.CourseCode,
                            CreditHours = cls.Course.CreditHours
                        },
                        Room = new RoomDto
                        {
                            Id = cls.Room.Id,
                            RoomName = cls.Room.RoomType.ToString() + "-" + cls.Room.RoomNumber,
                        },
                        TimePeriod = new TimePeriodDto
                        {
                            Id = cls.TimePeriod.Id,
                            Day = cls.TimePeriod.Day,
                            Time = cls.TimePeriod.StartTime + " - " + cls.TimePeriod.EndTime,
                        },
                        Instructor = new InstructorDto
                        {
                            Id = cls.Instructor.Id,
                            Name = cls.Instructor.PersonInfo?.FirstName + " " + cls.Instructor.PersonInfo?.MiddleName + " " + cls.Instructor.PersonInfo?.LastName
                        },
                    }).ToList()
                }).ToList(),
            });
        }

        return departmentClassesDtos;
    }
}

/*



*/
