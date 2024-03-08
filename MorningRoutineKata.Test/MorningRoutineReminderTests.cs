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
        IMorningRoutine morningRoutine = new MorningRoutine();
        
        // act
        string activityToDo = morningRoutine.WhatShouldIDoNow();
        
        // assert
        activityToDo.Should().Be("Do exercise");
    }

    [Test]
    public void remind_me_to_read_and_study_from_07_00_to_07_59()
    {
        // arrange
        IMorningRoutine morningRoutine = new MorningRoutine();
        
        // act
        string activityToDo = morningRoutine.WhatShouldIDoNow();
        
        // assert
        activityToDo.Should().Be("Read and study");
    }
}