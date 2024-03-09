namespace MorningRoutineKata.Test;

public class MorningRoutineBuilder
{
    private IClock _clock;
    private readonly List<RoutineConfiguration> _configurations;

    public MorningRoutineBuilder()
    {
        _configurations = new List<RoutineConfiguration>();
    }

    public MorningRoutineBuilder WithClock(IClock clockMockObject)
    {
        _clock = clockMockObject;
        return this;
    }

    public MorningRoutineBuilder WithConfiguration(TimeOnly from, TimeOnly to, string name)
    {
        _configurations.Add(new RoutineConfiguration(new TimeRange(from, to), name));
        return this;
    }

    public MorningRoutine Build()
    {
        return new MorningRoutine(_clock, _configurations);
    }
}