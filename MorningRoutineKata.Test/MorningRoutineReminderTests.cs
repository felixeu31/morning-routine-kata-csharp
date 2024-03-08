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
        MorningRoutineReminder reminder = new();
        
        // act
        string response = reminder.Remind();
        
        // assert
        response.Should().Be("Do exercise");
    }
}

public class MorningRoutineReminder
{
    public string Remind()
    {
        return "Do exercise";
    }
}