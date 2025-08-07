using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Domain.Model.Enums;

namespace ClassScheduler.Application.Features.Scheduler.Common;

public class Schedule
{
    public List<Class> Classes { get; set; } = [];
    public List<Conflict> Conflicts = [];
    public bool IsFitnessChanged = true;
    public double Fitness { get; set; } = -1;
    public int NumberOfConflicts { get; set; } = 0;
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
        var sections = _data.Sections ?? [];
        var periods = _data.TimeSlots;
        Random random = new();

        foreach (var section in sections)
        {
            var sectionCourses = section.DeptBatch?.Courses ?? [];
            foreach (var course in sectionCourses)
            {
                CreateClasses(course, section, RoomType.Lecture, course.LectureHour, periods, random);
                CreateClasses(course, section, RoomType.Lab, course.LabHour, periods, random);
            }
        }

        return this;
    }

    public Schedule FindAllConflicts()
    {
        Conflicts.Clear();
        var conflictsFound = new List<Conflict>();

        for (int i = 0; i < Classes.Count; i++)
        {
            for (int j = i + 1; j < Classes.Count; j++)
            {
                var class1 = Classes[i];
                var class2 = Classes[j];

                if (class1.TimeSlot != class2.TimeSlot || class1.Id == class2.Id)
                    continue;

                AddConflictsIfExist(class1, class2, conflictsFound);
            }
        }

        Conflicts.AddRange(conflictsFound);
        NumberOfConflicts = conflictsFound.Count;
        IsFitnessChanged = true;
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
                if ((class1.TimeSlot == filteredClass.TimeSlot) && (class1.Id != filteredClass.Id))
                {
                    if ((class1.Room == filteredClass.Room) || (class1.Instructor == filteredClass.Instructor) || (class1.Section == filteredClass.Section))
                    {
                        NumberOfConflicts += 1;
                    }
                }
            }
        }

        return 1 / (double)(NumberOfConflicts + 1);
    }


    private static void AddConflictsIfExist(Class class1, Class class2, List<Conflict> conflictsFound)
    {
        var conflictClasses = new List<Class> { class1, class2 };

        if (class1.Room == class2.Room)
        {
            conflictsFound.Add(new Conflict(ConflictType.RoomBooking, conflictClasses));
        }

        if (class1.Instructor == class2.Instructor)
        {
            conflictsFound.Add(new Conflict(ConflictType.InstructorBooking, conflictClasses));
        }

        if (class1.Section == class2.Section)
        {
            conflictsFound.Add(new Conflict(ConflictType.DepartmentBooking, conflictClasses));
        }
    }
    
    private void CreateClasses(Course course, Section section, RoomType roomType, int hours, ICollection<TimeSlot> periods, Random random)
    {

        if (hours <= 0) return;
        
        var room = _data.Rooms.FirstOrDefault(r => r.RoomType == roomType && r.IsAvailable) ?? throw new InvalidOperationException($"No available {roomType} room found");
        var instructorList = course.Instructors.ToList();
        var periodList = periods.ToList();

        for (int i = 0; i < hours; i++)
        {
            Classes.Add(new Class
            {
                Course = course,
                TimeSlot = GetRandomElement(periodList, random),
                Room = room,
                Instructor = GetRandomElement(instructorList, random),
                Section = section
            });
        }
    }

    private T GetRandomElement<T>(IList<T> list, Random random)
    {
        return list[random.Next(list.Count)];
    }

}

