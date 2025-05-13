namespace ClassScheduler.Application.Features.Scheduler.Common;
public class ClassSchedule
{
    public const int POPULATION_SIZE = 10;
    public const double MUTATION_RATE = 0.1;
    public const double CROSSOVER_RATE = 0.9;
    public const int TOURNAMENT_SELECTION_SIZE = 3;
    public const int NUMB_ELITE_SCHEDULES = 1;
    private int ScheduleNumber { get; set; } = 0;
    private int ClassNumber { get; set; } = 0;
    private int Counter { get; set; } = 0;
    private static DataSource _data;
}