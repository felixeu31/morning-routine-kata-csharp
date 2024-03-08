namespace MorningRoutineKata.Test;

public interface IMorningRoutine
{
    string WhatShouldIDoNow();
}

public class MorningRoutine : IMorningRoutine
{
    public string WhatShouldIDoNow()
    {
        return "Do exercise";
    }
}