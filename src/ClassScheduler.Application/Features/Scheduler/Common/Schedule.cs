using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Domain.Model.Enums;

namespace ClassScheduler.Application.Features.Scheduler.Common;
public class Schedule
{
    public List<Class> Classes { get; set; } = [];
    public List<Conflict> Conflicts = [];
    public bool IsFitnessChanged = true;
    public double Fitness { get; set; } = -1;
    public int NumbOfConflicts { get; set; } = 0;
    private readonly DataSource _data;
    public Schedule(DataSource data)
    {
        _data = data;
    }
    public Schedule(Schedule schedule)
    {
        _data = schedule._data;
        FindAllConflicts();
    }

    public Schedule Initialize()
    {
        var departments = _data.Departments;
        var periods = _data.TimePeriods;

        if (departments is not null)
        {
            foreach (var dept in departments)
            {
                var deptCourses = dept.Courses;
                if (deptCourses is not null)
                {
                    foreach (var course in deptCourses)
                    {
                        int lectureHours = course.LectureHours;
                        int labHours = course.LabHours;

                        for (int i = 0; i < lectureHours; i++)
                        {
                            Room room = _data.Rooms.Where(rm => rm.RoomType == RoomType.Lecture && rm.IsAvailable).First();
                            Class newClass = new()
                            {
                                Course = course,
                                TimePeriod = periods.ToList()[(int)(periods.Count * new Random().NextDouble())],
                                Room = room,
                                Instructor = course.Instructors.ToList()[(int)(course.Instructors.Count * new Random().NextDouble())],
                                Department = dept
                            };

                            Classes.Add(newClass);
                        }

                        for (int i = 0; i < labHours; i++)
                        {
                            Room room = _data.Rooms.Where(rm => rm.RoomType == RoomType.Lab && rm.IsAvailable).First(); ;
                            Class newClass = new()
                            {
                                Course = course,
                                TimePeriod = periods.ToList()[(int)(periods.Count * new Random().NextDouble())],
                                Room = room,
                                Instructor = course.Instructors.ToList()[(int)(course.Instructors.Count * new Random().NextDouble())],
                                Department = dept
                            };
                            Classes.Add(newClass);
                        }
                    }
                }
            }
        }

        return this;
    }
    public Schedule FindAllConflicts()
    {
        IList<Class> conflictBetweenClasses = [];

        foreach (var class1 in Classes)
        {
            var filteredClasses = Classes.Where(class2 => Classes.IndexOf(class2) >= Classes.IndexOf(class1));

            foreach (var filteredClass in filteredClasses)
            {
                if ((class1.TimePeriod == filteredClass.TimePeriod) && (class1.Id != filteredClass.Id))
                {
                    if (class1.Room == filteredClass.Room)
                    {
                        conflictBetweenClasses.Add(class1);
                        conflictBetweenClasses.Add(filteredClass);
                        Conflict conflict = new(ConflictType.RoomBooking, conflictBetweenClasses);
                        Conflicts.Add(conflict);
                    }

                    if (class1.Instructor == filteredClass.Instructor)
                    {
                        conflictBetweenClasses.Add(class1);
                        conflictBetweenClasses.Add(filteredClass);
                        Conflict conflict = new(ConflictType.InstructorBooking, conflictBetweenClasses);
                        Conflicts.Add(conflict);
                    }

                    if (class1.Department == filteredClass.Department)
                    {
                        conflictBetweenClasses.Add(class1);
                        conflictBetweenClasses.Add(filteredClass);
                        Conflict conflict = new(ConflictType.InstructorBooking, conflictBetweenClasses);
                        Conflicts.Add(conflict);
                    }
                }
            }
        }

        return this;
    }

    public double GetFitness()
    {
        if (IsFitnessChanged == true)
        {
            Fitness = CalculateFitness();
            IsFitnessChanged = false;
        }
        return Fitness;
    }
    private double CalculateFitness()
    {
        foreach (var class1 in Classes)
        {
            var filteredClasses = Classes.Where(class2 => Classes.IndexOf(class2) >= Classes.IndexOf(class1));

            foreach (var filteredClass in filteredClasses)
            {
                if ((class1.TimePeriod == filteredClass.TimePeriod) && (class1.Id != filteredClass.Id))
                {
                    if ((class1.Room == filteredClass.Room) || (class1.Instructor == filteredClass.Instructor) || (class1.Department == filteredClass.Department))
                    {
                        NumbOfConflicts += 1;
                    }
                }
            }
        }

        return 1 / (double)(NumbOfConflicts + 1);
    }

    public bool SaveClasses()
    {
        if (NumbOfConflicts == 0)
        {

        }
        return false;
    }

}

