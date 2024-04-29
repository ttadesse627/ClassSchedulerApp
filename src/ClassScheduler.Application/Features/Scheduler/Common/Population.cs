namespace ClassScheduler.Application.Features.Scheduler.Common;
public class Population
{
    public ICollection<Schedule> Schedules { get; set; } = [];
    public Population(int size, DataSource data)
    {
        for (int i = 0; i < size; i++)
        {
            Schedules.Add(new Schedule(data).Initialize());
        }
    }

    public Population SortByFitness()
    {
        var resp = Schedules.OrderBy((schedule1) =>
        {
            int returnValue = 0;
            if (schedule1.GetFitness() >= schedule1.GetFitness())
            {
                returnValue = -1;
            }
            else returnValue = 1;
            return returnValue;
        });

        return this;
    }
}
