namespace MorningRoutineKata.Test;
using FluentAssertions;

public class MorningRoutineReminderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void remind_me_to_do_exercise_from_06_00_to_06_59()
    {
        // arrange
        MorningRoutine reminder = new();
        
        // act
        string activityToDo = reminder.WhatShouldIDoNow();
        
        // assert
        activityToDo.Should().Be("Do exercise");
    }
}

public class MorningRoutine
{
    public string WhatShouldIDoNow()
    {
        return "Do exercise";
    }
}