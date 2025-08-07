using ClassScheduler.Application.Contracts.ResponseDtos.ScheduleResponseDtos;
using ClassScheduler.Application.Interfaces.Persistence;
using MediatR;

namespace ClassScheduler.Application.Features.Scheduler.Query;
public record GetScheduleQuery(Guid SectionId) : IRequest<List<SectionClassesDto>> { }
public class GetScheduleQueryHandler(IClassRepository classRepository) : IRequestHandler<GetScheduleQuery, List<SectionClassesDto>>
{
    private readonly IClassRepository _classRepository = classRepository;

    public async Task<List<SectionClassesDto>> Handle(GetScheduleQuery query, CancellationToken cancellationToken)
    {
        List<SectionClassesDto> sectionClassesDtos = [];

        var sectionClasses = await _classRepository.GetBySectionAsync(query.SectionId);
        foreach (var deptCls in sectionClasses.GroupBy(cl => cl.Section))
        {
            sectionClassesDtos.Add(new SectionClassesDto
            {
                Id = deptCls.Key.Id,
                Name = deptCls.Key.Name,
                ShortName = deptCls.Key.Name,
                DayGroups = deptCls.GroupBy(cl => cl.TimeSlot.Day).Select(dg => new DayGroupDto
                {
                    Day = dg.Key.ToString(),
                    Classes = dg.Select(cls => new ClassDto
                    {
                        Id = cls.Id,
                        Course = new CourseDto
                        {
                            Id = cls.Course.Id,
                            Name = cls.Course.Name,
                            Code = cls.Course.Code,
                            CreditHour = cls.Course.CreditHour
                        },
                        Room = new RoomDto
                        {
                            Id = cls.Room.Id,
                            RoomName = cls.Room.RoomType.ToString() + "-" + cls.Room.Code,
                        },
                        TimeSlot = new TimeSlotDto
                        {
                            Id = cls.TimeSlot.Id,
                            Day = cls.TimeSlot.Day.ToString(),
                            Time = cls.TimeSlot.StartTime + " - " + cls.TimeSlot.EndTime,
                        },
                        Instructor = new InstructorDto
                        {
                            Id = cls.Instructor.Id,
                            Name = cls.Instructor.Person?.FirstName + " " + cls.Instructor.Person?.MiddleName + " " + cls.Instructor.Person?.LastName
                        },
                    }).ToList()
                }).ToList(),
            });
        }

        return sectionClassesDtos;
    }
}

/*



*/
