namespace MorningRoutineKata.Test;

public interface IMorningRoutine
{
    string WhatShouldIDoNow();
}

public class MorningRoutine : IMorningRoutine
{
    private readonly IClock _clock;
    private readonly List<RoutineConfiguration> _configurations;

    public MorningRoutine(IClock clock)
    {
        _clock = clock;
        _configurations = new ();
    }
    
    public MorningRoutine WithConfiguration(TimeOnly from, TimeOnly to, string name)
    {
        if (AnyExistingConfigurationOveralps(from, to))
        {
            throw new InvalidRoutineConfigurationException();
        }
        _configurations.Add(new RoutineConfiguration(from, to, name));
        return this;
    }

    public string WhatShouldIDoNow()
    {
        return GetMatchingConfiguration(_clock.Now())?.Name ?? "No activity";
    }

    private bool AnyExistingConfigurationOveralps(TimeOnly from, TimeOnly to)
    {
        return _configurations.Any(existing => existing.IsWithin(from) || existing.IsWithin(to));
    }

    private RoutineConfiguration? GetMatchingConfiguration(TimeOnly now)
    {
        return _configurations.FirstOrDefault(x => x.IsWithin(now));
    }
}