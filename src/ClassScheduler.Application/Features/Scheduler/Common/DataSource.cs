using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Features.Scheduler.Common;
public class DataSource
{
    public ICollection<Department> Departments { get; set; } = [];
    public ICollection<Course> Courses { get; set; } = [];
    public ICollection<Room> Rooms { get; set; } = [];
    public ICollection<Instructor> Instructors { get; set; } = [];
    public ICollection<TimePeriod> TimePeriods { get; set; } = [];

    private readonly IDepartmentRepository _departmentRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IInstructorRepository _instructorRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly ITimePeriodRepository _timePeriodRepository;
    public int NumberOfClasses = 0;

    public DataSource(IDepartmentRepository departmentRepository, ICourseRepository courseRepository, IInstructorRepository instructorRepository, IRoomRepository roomRepository, ITimePeriodRepository timePeriodRepository)
    {
        _departmentRepository = departmentRepository;
        _courseRepository = courseRepository;
        _instructorRepository = instructorRepository;
        _roomRepository = roomRepository;
        _timePeriodRepository = timePeriodRepository;

        InitializeData().GetAwaiter().GetResult();



    }
    public async Task<DataSource> InitializeData()
    {
        Departments = await GetDepartmentsAsync();
        Courses = await GetCoursesAsync();
        Rooms = await GetRoomsAsync();
        TimePeriods = await GetPeriodsAsync();
        Instructors = await GetInstructorsAsync();
        return this;
    }
    public async Task<List<Department>> GetDepartmentsAsync()
    {
        List<Department> departments = [];
        var depts = await _departmentRepository.GetAllAsync();
        if (depts is not null)
        {
            departments = depts;
        }

        return departments;
    }
    public async Task<List<Course>> GetCoursesAsync()
    {
        List<Course> courses = [];
        var crs = await _courseRepository.GetAllAsync();
        if (crs is not null)
        {
            courses = crs;
        }

        return courses;
    }
    public async Task<List<Room>> GetRoomsAsync()
    {
        List<Room> rooms = [];
        var rms = await _roomRepository.GetAllAsync();
        if (rms is not null)
        {
            rooms = rms;
        }
        Rooms = rooms;
        return rooms;
    }
    public async Task<List<Instructor>> GetInstructorsAsync()
    {
        IList<Instructor> instructors = [];
        var instrctrs = await _instructorRepository.GetListAsync();
        if (instrctrs is not null)
        {
            instructors = instrctrs;
        }

        Instructors = instructors;
        return [.. instructors];
    }
    public async Task<List<TimePeriod>> GetPeriodsAsync()
    {
        List<TimePeriod> timePeriods = [];
        var periods = await _timePeriodRepository.GetAllAsync();
        if (periods is not null)
        {
            timePeriods = periods;
        }

        TimePeriods = timePeriods;

        return timePeriods;
    }
    public async Task<int> GetNumberOfClasses()
    {
        await Task.CompletedTask;
        if (Departments.Count > 0)
        {
            foreach (var department in Departments)
            {
                NumberOfClasses += department.Courses.Count;
            }
        }

        return NumberOfClasses;
    }

}