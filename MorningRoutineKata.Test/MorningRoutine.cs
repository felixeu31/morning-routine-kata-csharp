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
        _configurations.Add(new RoutineConfiguration(from, to, name));
        return this;
    }
    public string WhatShouldIDoNow()
    {
        var now = TimeOnly.FromDateTime(_clock.Now());
        
        var matchedConfiguration = _configurations.FirstOrDefault(x => x.IsWithin(now));

        if (matchedConfiguration != null)
            return matchedConfiguration.Name;

        return "No activity";
    }
}