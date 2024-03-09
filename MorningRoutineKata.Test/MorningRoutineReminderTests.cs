using Moq;

namespace MorningRoutineKata.Test;
using FluentAssertions;

public class MorningRoutineReminderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("06:00", "Do exercise")]
    [TestCase("06:30", "Do exercise")]
    [TestCase("07:00", "Read and study")]
    [TestCase("07:30", "Read and study")]
    [TestCase("08:00", "Have breakfast")]
    [TestCase("08:30", "Have breakfast")]
    [TestCase("09:15", "Coding time")]
    [TestCase("09:45", "Watch Udemy course")]
    [TestCase("04:30", "No activity")]
    [TestCase("12:30", "No activity")]
    public void WhatShouldIDoNow_GivenTime_ReturnsExpectedActivity(string time, string expectedActivity)
    {
        // arrange
        Mock<IClock> clockMock = new Mock<IClock>();
        clockMock.Setup(x => x.Now()).Returns(TimeOnly.Parse(time));
        IMorningRoutine morningRoutine = new MorningRoutine(clockMock.Object)
            .WithConfiguration(TimeOnly.Parse("06:00"), TimeOnly.Parse("06:59"), "Do exercise")
            .WithConfiguration(TimeOnly.Parse("07:00"), TimeOnly.Parse("07:59"), "Read and study")
            .WithConfiguration(TimeOnly.Parse("08:00"), TimeOnly.Parse("08:59"), "Have breakfast")
            .WithConfiguration(TimeOnly.Parse("09:00"), TimeOnly.Parse("09:29"), "Coding time")
            .WithConfiguration(TimeOnly.Parse("09:30"), TimeOnly.Parse("09:59"), "Watch Udemy course");

        // act
        var activityToDo = morningRoutine.WhatShouldIDoNow();

        // assert
        activityToDo.Should().Be(expectedActivity);
    }
}