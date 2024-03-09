namespace MorningRoutineKata.Test;

public record RoutineConfiguration(TimeOnly From, TimeOnly To, string Name)
{
    public bool IsWithin(TimeOnly time)
    {
        return From <= time && time <= To;
    }
};