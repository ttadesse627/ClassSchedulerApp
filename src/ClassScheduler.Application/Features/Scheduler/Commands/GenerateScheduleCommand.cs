using ClassScheduler.Application.Contracts.ResponseDtos.Common;
using ClassScheduler.Application.Contracts.ResponseDtos.ScheduleResponseDtos;
using ClassScheduler.Application.Features.Scheduler.Common;
using ClassScheduler.Application.Interfaces.Persistence;
using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Domain.Model.Values;
using MediatR;

namespace ClassScheduler.Application.Features.Scheduler.Commands;
public class GenerateScheduleCommand : IRequest<ServiceResponse<int>> { }
public class GenerateScheduleCommandHandler : IRequestHandler<GenerateScheduleCommand, ServiceResponse<int>>
{
    private int ScheduleNumber = 0;
    private int ClassNumber = 0;
    private int Counter = 0;
    private readonly DataSource _data;

    private readonly IClassRepository _classRepository;
    private readonly IDepartmentRepository _departmentRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IInstructorRepository _instructorRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly ITimePeriodRepository _timePeriodRepository;

    public GenerateScheduleCommandHandler(IDepartmentRepository departmentRepository, ICourseRepository courseRepository, IInstructorRepository instructorRepository, IRoomRepository roomRepository, ITimePeriodRepository timePeriodRepository, IClassRepository classRepository)
    {
        _classRepository = classRepository;
        _timePeriodRepository = timePeriodRepository;
        _departmentRepository = departmentRepository;
        _courseRepository = courseRepository;
        _instructorRepository = instructorRepository;
        _roomRepository = roomRepository;
        _data = new(_departmentRepository, _courseRepository, _instructorRepository, _roomRepository, _timePeriodRepository);

    }
    public async Task<ServiceResponse<int>> Handle(GenerateScheduleCommand command, CancellationToken cancellationToken)
    {
        ServiceResponse<int> response = new();

        int generationNumber = 1;
        List<Class> classes = [];

        Algorithm geneticAlgorithm = new(_data);
        Population population = new Population(ConstantValues.POPULATION_SIZE, _data).SortByFitness();

        var selectedSchedule = population.Schedules.Where(sched => sched.Conflicts.Count == 0).First();

        if (selectedSchedule.GetFitness() == 1)
        {
            classes.AddRange(selectedSchedule.Classes);
        }

        while (selectedSchedule.GetFitness() != 1.0)
        {
            population = geneticAlgorithm.Evolve(population).SortByFitness();
            ScheduleNumber = 0;
            generationNumber += 1;

            selectedSchedule = population.Schedules.Where(sched => sched.Conflicts.Count == 0).First();

            if (selectedSchedule.GetFitness() == 1)
            {
                classes.AddRange(selectedSchedule.Classes);
            }
        }

        if (classes.Count != 0)
        {
            response.Success = await _classRepository.CreateListAsync(classes, cancellationToken);
            if (response.Success)
            {
                response.Message = "Successfully generated classes and saved!";
                response.Data = classes.Count;
            }
            else
            {
                response.Message = "An error occurred while trying to save classes.";
                response.Errors.Add("Unable to save classes.");
            }
        }
        else
        {
            response.Message = "The generated schedules could not be conflict free, try it again.";
            response.Errors.Add("Unable to generate conflict free schedule");
        }

        return response;
    }
}
