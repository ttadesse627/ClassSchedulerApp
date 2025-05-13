using ClassScheduler.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Utility.Data;
public class DataSeeder
{
    internal static void SeedTime(ModelBuilder builder)
    {
        var timePeriods = new List<TimePeriod>{
            new() {
                Id = Guid.NewGuid(),
                Day = "Monday",
                StartTime = "08:00 AM",
                EndTime = "08:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Monday",
                StartTime = "09:00 AM",
                EndTime = "09:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Monday",
                StartTime = "10:00 AM",
                EndTime = "10:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Monday",
                StartTime = "11:00 AM",
                EndTime = "11:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Monday",
                StartTime = "01:00 PM",
                EndTime = "01:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Monday",
                StartTime = "02:00 PM",
                EndTime = "02:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Monday",
                StartTime = "03:00 PM",
                EndTime = "03:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Monday",
                StartTime = "04:00 PM",
                EndTime = "04:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Tuesday",
                StartTime = "08:00 AM",
                EndTime = "08:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Tuesday",
                StartTime = "09:00 AM",
                EndTime = "09:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Tuesday",
                StartTime = "10:00 AM",
                EndTime = "10:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Tuesday",
                StartTime = "11:00 AM",
                EndTime = "11:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Tuesday",
                StartTime = "01:00 PM",
                EndTime = "01:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Tuesday",
                StartTime = "02:00 PM",
                EndTime = "02:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Tuesday",
                StartTime = "03:00 PM",
                EndTime = "03:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Tuesday",
                StartTime = "04:00 PM",
                EndTime = "04:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Wednesday",
                StartTime = "08:00 AM",
                EndTime = "08:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Wednesday",
                StartTime = "09:00 AM",
                EndTime = "09:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Wednesday",
                StartTime = "10:00 AM",
                EndTime = "10:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Wednesday",
                StartTime = "11:00 AM",
                EndTime = "11:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Wednesday",
                StartTime = "01:00 PM",
                EndTime = "01:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Wednesday",
                StartTime = "02:00 PM",
                EndTime = "02:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Wednesday",
                StartTime = "03:00 PM",
                EndTime = "03:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Wednesday",
                StartTime = "04:00 PM",
                EndTime = "04:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Thursday",
                StartTime = "08:00 AM",
                EndTime = "08:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Thursday",
                StartTime = "09:00 AM",
                EndTime = "09:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Thursday",
                StartTime = "10:00 AM",
                EndTime = "10:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Thursday",
                StartTime = "11:00 AM",
                EndTime = "11:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Thursday",
                StartTime = "01:00 PM",
                EndTime = "01:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Thursday",
                StartTime = "02:00 PM",
                EndTime = "02:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Thursday",
                StartTime = "03:00 PM",
                EndTime = "03:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Thursday",
                StartTime = "04:00 PM",
                EndTime = "04:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Friday",
                StartTime = "08:00 AM",
                EndTime = "08:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Friday",
                StartTime = "09:00 AM",
                EndTime = "09:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Friday",
                StartTime = "10:00 AM",
                EndTime = "10:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Friday",
                StartTime = "11:00 AM",
                EndTime = "11:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Friday",
                StartTime = "01:00 PM",
                EndTime = "01:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Friday",
                StartTime = "02:00 PM",
                EndTime = "02:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Friday",
                StartTime = "03:00 PM",
                EndTime = "03:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Friday",
                StartTime = "04:00 PM",
                EndTime = "04:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Saturday",
                StartTime = "08:00 AM",
                EndTime = "08:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Saturday",
                StartTime = "09:00 AM",
                EndTime = "09:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Saturday",
                StartTime = "10:00 AM",
                EndTime = "10:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Saturday",
                StartTime = "11:00 AM",
                EndTime = "11:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Saturday",
                StartTime = "01:00 PM",
                EndTime = "01:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Saturday",
                StartTime = "02:00 PM",
                EndTime = "02:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Saturday",
                StartTime = "03:00 PM",
                EndTime = "03:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = "Saturday",
                StartTime = "04:00 PM",
                EndTime = "04:50 PM",
            },
        };

        builder.Entity<TimePeriod>().HasData(timePeriods);

    }
}