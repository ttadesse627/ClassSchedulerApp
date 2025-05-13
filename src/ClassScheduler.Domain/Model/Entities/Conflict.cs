using ClassScheduler.Domain.Model.Enums;

namespace ClassScheduler.Domain.Model.Entities;
public class Conflict(ConflictType conflictType, ICollection<Class> classConflicts)
{
    public ConflictType ConflictType = conflictType;
    public ICollection<Class> ClassConflicts = classConflicts;

    public string GetConflict()
    {
        return ConflictType + "" + ClassConflicts;
    }
}