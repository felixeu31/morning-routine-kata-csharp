namespace MorningRoutineKata.Test;

public interface IMorningRoutine
{
    string WhatShouldIDoNow();
}

public class MorningRoutine : IMorningRoutine
{
    private readonly IClock _clock;
    private readonly IReadOnlyList<RoutineConfiguration> _configurations;

    public MorningRoutine(IClock clock)
    {
        _clock = clock;
        _configurations = new List<RoutineConfiguration>()
        {
            new RoutineConfiguration(new TimeRange(TimeOnly.Parse("06:00:00"), TimeOnly.Parse("06:59:00")), "Do exercise"),
            new RoutineConfiguration(new TimeRange(TimeOnly.Parse("07:00:00"), TimeOnly.Parse("07:59:00")), "Read and study"),
            new RoutineConfiguration(new TimeRange(TimeOnly.Parse("08:00:00"), TimeOnly.Parse("08:59:00")), "Have breakfast")
        };
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