using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;

namespace ClassScheduler.Application.Features.Scheduler.Common;
public class DataSource
{
    public ICollection<Department> Departments { get; set; } = [];
    public ICollection<DeptBatch> DeptBatches { get; set; } = [];
    public ICollection<Section> Sections { get; set; } = [];
    public ICollection<Course> Courses { get; set; } = [];
    public ICollection<Room> Rooms { get; set; } = [];
    public ICollection<Instructor> Instructors { get; set; } = [];
    public ICollection<TimeSlot> TimeSlots { get; set; } = [];

    private readonly IDepartmentRepository _departmentRepository;
    private readonly IDeptBatchRepository _deptBatchRepository;
    private readonly ISectionRepository _sectionRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IInstructorRepository _instructorRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly ITimeSlotRepository _timeSlotRepository;
    public int NumberOfClasses = 0;

    public DataSource(IDepartmentRepository departmentRepository, IDeptBatchRepository deptBatchRepository, ISectionRepository sectionRepository, ICourseRepository courseRepository,IInstructorRepository instructorRepository,
        IRoomRepository roomRepository, ITimeSlotRepository TimeSlotRepository)
    {
        _departmentRepository = departmentRepository;
        _courseRepository = courseRepository;
        _instructorRepository = instructorRepository;
        _roomRepository = roomRepository;
        _timeSlotRepository = TimeSlotRepository;
        _deptBatchRepository = deptBatchRepository;
        _sectionRepository = sectionRepository;

        InitializeData().GetAwaiter().GetResult();



    }
    public async Task<DataSource> InitializeData()
    {
        Departments = await _departmentRepository.GetAllAsync()?? [];
        DeptBatches = await _deptBatchRepository.GetAllAsync()?? [];
        Sections = await _sectionRepository.GetAllAsync()?? [];
        Courses = await _courseRepository.GetAllAsync()?? [];
        Rooms = await _roomRepository.GetAllAsync()?? [];
        TimeSlots = await _timeSlotRepository.GetAllAsync()?? [];
        Instructors = await _instructorRepository.GetListAsync()?? [];
        NumberOfClasses = await GetNumberOfClassesAsync();
        return this;
    }
    public async Task<int> GetNumberOfClassesAsync()
    {
        await Task.CompletedTask;
        if (DeptBatches.Count > 0)
        {
            foreach (var batch in DeptBatches)
            {
                NumberOfClasses += batch.Courses.Count;
            }
        }

        return NumberOfClasses;
    }

}