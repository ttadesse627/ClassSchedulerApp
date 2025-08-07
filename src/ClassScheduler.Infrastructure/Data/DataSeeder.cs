using ClassScheduler.Domain.Model.Entities;
using ClassScheduler.Domain.Model.Enums;
using Microsoft.EntityFrameworkCore;

namespace ClassScheduler.Infrastructure.Data;
public class DataSeeder
{
    internal static void SeedTime(ModelBuilder builder)
    {
        var TimeSlots = new List<TimeSlot>{
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Monday,
                StartTime = "08:00 AM",
                EndTime = "08:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Monday,
                StartTime = "09:00 AM",
                EndTime = "09:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Monday,
                StartTime = "10:00 AM",
                EndTime = "10:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Monday,
                StartTime = "11:00 AM",
                EndTime = "11:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Monday,
                StartTime = "01:00 PM",
                EndTime = "01:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Monday,
                StartTime = "02:00 PM",
                EndTime = "02:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Monday,
                StartTime = "03:00 PM",
                EndTime = "03:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Monday,
                StartTime = "04:00 PM",
                EndTime = "04:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Tuesday,
                StartTime = "08:00 AM",
                EndTime = "08:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Tuesday,
                StartTime = "09:00 AM",
                EndTime = "09:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Tuesday,
                StartTime = "10:00 AM",
                EndTime = "10:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Tuesday,
                StartTime = "11:00 AM",
                EndTime = "11:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Tuesday,
                StartTime = "01:00 PM",
                EndTime = "01:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Tuesday,
                StartTime = "02:00 PM",
                EndTime = "02:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Tuesday,
                StartTime = "03:00 PM",
                EndTime = "03:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Tuesday,
                StartTime = "04:00 PM",
                EndTime = "04:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Wednesday,
                StartTime = "08:00 AM",
                EndTime = "08:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Wednesday,
                StartTime = "09:00 AM",
                EndTime = "09:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Wednesday,
                StartTime = "10:00 AM",
                EndTime = "10:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Wednesday,
                StartTime = "11:00 AM",
                EndTime = "11:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Wednesday,
                StartTime = "01:00 PM",
                EndTime = "01:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Wednesday,
                StartTime = "02:00 PM",
                EndTime = "02:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Wednesday,
                StartTime = "03:00 PM",
                EndTime = "03:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Wednesday,
                StartTime = "04:00 PM",
                EndTime = "04:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Thrusday,
                StartTime = "08:00 AM",
                EndTime = "08:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Thrusday,
                StartTime = "09:00 AM",
                EndTime = "09:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Thrusday,
                StartTime = "10:00 AM",
                EndTime = "10:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Thrusday,
                StartTime = "11:00 AM",
                EndTime = "11:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Thrusday,
                StartTime = "01:00 PM",
                EndTime = "01:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Thrusday,
                StartTime = "02:00 PM",
                EndTime = "02:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Thrusday,
                StartTime = "03:00 PM",
                EndTime = "03:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Thrusday,
                StartTime = "04:00 PM",
                EndTime = "04:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Friday,
                StartTime = "08:00 AM",
                EndTime = "08:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Friday,
                StartTime = "09:00 AM",
                EndTime = "09:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Friday,
                StartTime = "10:00 AM",
                EndTime = "10:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Friday,
                StartTime = "11:00 AM",
                EndTime = "11:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Friday,
                StartTime = "01:00 PM",
                EndTime = "01:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Friday,
                StartTime = "02:00 PM",
                EndTime = "02:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Friday,
                StartTime = "03:00 PM",
                EndTime = "03:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Friday,
                StartTime = "04:00 PM",
                EndTime = "04:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Saturday,
                StartTime = "08:00 AM",
                EndTime = "08:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Saturday,
                StartTime = "09:00 AM",
                EndTime = "09:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Saturday,
                StartTime = "10:00 AM",
                EndTime = "10:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Saturday,
                StartTime = "11:00 AM",
                EndTime = "11:50 AM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Saturday,
                StartTime = "01:00 PM",
                EndTime = "01:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Saturday,
                StartTime = "02:00 PM",
                EndTime = "02:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Saturday,
                StartTime = "03:00 PM",
                EndTime = "03:50 PM",
            },
            new() {
                Id = Guid.NewGuid(),
                Day = WeekDay.Saturday,
                StartTime = "04:00 PM",
                EndTime = "04:50 PM",
            },
        };

        builder.Entity<TimeSlot>().HasData(TimeSlots);

    }
}