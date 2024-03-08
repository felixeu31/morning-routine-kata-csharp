namespace MorningRoutineKata.Test;

public interface IMorningRoutine
{
    string WhatShouldIDoNow();
}

public class MorningRoutine : IMorningRoutine
{
    private readonly IClock _clock;

    public MorningRoutine(IClock clock)
    {
        _clock = clock;
    }
    public string WhatShouldIDoNow()
    {
        if (_clock.Now().Hour == 7)
            return "Read and study";
        
        return "Do exercise";
    }
}