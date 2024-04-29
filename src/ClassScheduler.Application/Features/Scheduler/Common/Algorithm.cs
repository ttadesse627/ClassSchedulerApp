using ClassScheduler.Domain.Model.Values;

namespace ClassScheduler.Application.Features.Scheduler.Common;
public class Algorithm(DataSource data)
{
    private readonly DataSource _data = data;

    public Population Evolve(Population population)
    {
        return MutatePopulation(CrossOverPopulation(population));
    }

    public Population CrossOverPopulation(Population population)
    {
        Population crossoverPopulation = new(population.Schedules.Count, _data);

        for (int x = 0; x < ConstantValues.NUMB_ELITE_SCHEDULES; x++)
        {
            crossoverPopulation.Schedules.ToList()[x] = population.Schedules.ToList()[x];
        }
        for (int x = ConstantValues.NUMB_ELITE_SCHEDULES; x < population.Schedules.Count; x++)
        {
            if (ConstantValues.CROSSOVER_RATE > new Random().NextDouble())
            {
                Schedule schedule1 = SelectTournamentPopulation(population).SortByFitness().Schedules.First();
                Schedule schedule2 = SelectTournamentPopulation(population).SortByFitness().Schedules.ToList()[1];
                crossoverPopulation.Schedules.ToList()[x] = CrossOverSchedule(schedule1, schedule2);
            }
            else
                crossoverPopulation.Schedules.ToList()[x] = population.Schedules.ToList()[x];
        }

        return crossoverPopulation;
    }

    public Schedule CrossOverSchedule(Schedule schedule1, Schedule schedule2)
    {
        Schedule crossOverSchedule = new Schedule(_data).Initialize();

        for (int x = 0; x < crossOverSchedule.Classes.Count; x++)
        {
            if (new Random().NextDouble() > 0.5)
                crossOverSchedule.Classes.ToList()[x] = schedule1.Classes.ToList()[x];
            else crossOverSchedule.Classes.ToList()[x] = schedule2.Classes.ToList()[x];
        }

        return crossOverSchedule;
    }

    Population MutatePopulation(Population population)
    {
        Population mutatePopulation = new(population.Schedules.Count, _data);
        ICollection<Schedule> schedules = mutatePopulation.Schedules;
        for (int x = 0; x < ConstantValues.NUMB_ELITE_SCHEDULES; x++)
        {
            schedules.ToList()[x] = population.Schedules.ToList()[x];
        }

        for (int x = ConstantValues.NUMB_ELITE_SCHEDULES; x < population.Schedules.Count; x++)
        {
            schedules.ToList()[x] = MutateSchedule(population.Schedules.ToList()[x]);
        }

        return mutatePopulation;
    }

    Schedule MutateSchedule(Schedule mutateSchedule)
    {
        Schedule schedule = new Schedule(_data).Initialize();

        for (int x = 0; x < mutateSchedule.Classes.Count; x++)
        {
            if (ConstantValues.MUTATION_RATE > new Random().NextDouble())
            {
                mutateSchedule.Classes.ToList()[x] = schedule.Classes.ToList()[x];
            }
        }

        return mutateSchedule;
    }

    Population SelectTournamentPopulation(Population population)
    {
        Population tournamentPopulation = new(ConstantValues.TOURNAMENT_SELECTION_SIZE, _data);

        for (int x = 0; x < ConstantValues.TOURNAMENT_SELECTION_SIZE; x++)
        {
            tournamentPopulation.Schedules.ToList()[x] = population.Schedules.ToList()[(int)(new Random().NextDouble() * population.Schedules.Count)];
        }

        return tournamentPopulation;
    }

}