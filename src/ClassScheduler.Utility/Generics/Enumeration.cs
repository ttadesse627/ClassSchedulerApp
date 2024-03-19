using System.Reflection;

namespace ClassScheduler.Utility.Generics;

public abstract class Enumeration<TEnum>(Guid id, string name) : IEquatable<Enumeration<TEnum>>
    where TEnum : Enumeration<TEnum>
{
    private static readonly Dictionary<Guid, TEnum> Enumerations = CreateEnumerations();
    public Guid Id { get; init; } = id;
    public string Name { get; init; } = name;
    public static TEnum? FromValue(Guid id)
    {
        return Enumerations.TryGetValue(
            id,
            out TEnum? enumeration) ?
                enumeration :
                default;
    }

    public static TEnum? FromName(string name)
    {
        return Enumerations
            .Values
            .SingleOrDefault(e => e.Name == name);
    }

    public bool Equals(Enumeration<TEnum>? other)
    {
        if (other is null)
        {
            return false;
        }

        return GetType() == other.GetType() &&
               Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        return obj is Enumeration<TEnum> other &&
               Equals(other);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string ToString()
    {
        return Name;
    }

    private static Dictionary<Guid, TEnum> CreateEnumerations()
    {
        var enumerationType = typeof(TEnum);

        var fieldsForType = enumerationType
            .GetFields(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.FlattenHierarchy)
            .Where(fieldInfo =>
                enumerationType.IsAssignableFrom(fieldInfo.FieldType))
            .Select(fieldInfo =>
                (TEnum)fieldInfo.GetValue(default)!);

        return fieldsForType.ToDictionary(x => x.Id);
    }
}