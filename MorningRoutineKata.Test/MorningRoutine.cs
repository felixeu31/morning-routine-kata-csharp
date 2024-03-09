namespace MorningRoutineKata.Test;

public interface IMorningRoutine
{
    string WhatShouldIDoNow();
}

public class MorningRoutine : IMorningRoutine
{
    private readonly IClock _clock;
    private readonly IList<RoutineConfiguration> _configurations;

    public MorningRoutine(IClock clock, IList<RoutineConfiguration> configurations)
    {
        _clock = clock;
        _configurations = configurations;
    }
    public string WhatShouldIDoNow()
    {
        var now = TimeOnly.FromDateTime(_clock.Now());
        
        var matchedConfiguration = _configurations.FirstOrDefault(x => x.TimeRange.IsWithin(now));

        if (matchedConfiguration != null)
            return matchedConfiguration.Name;

        return "No activity";
    }
}

public record TimeRange(TimeOnly From, TimeOnly To)
{
    public bool IsWithin(TimeOnly time)
    {
        return From <= time && time <= To;
    }
};

public record RoutineConfiguration(TimeRange TimeRange, string Name);