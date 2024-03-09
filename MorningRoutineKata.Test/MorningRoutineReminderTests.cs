using Moq;

namespace MorningRoutineKata.Test;
using FluentAssertions;

public class MorningRoutineReminderTests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase("2024-03-08 06:00:00", "Do exercise")]
    [TestCase("2024-03-08 06:30:00", "Do exercise")]
    [TestCase("2024-03-08 07:00:00", "Read and study")]
    [TestCase("2024-03-08 07:30:00", "Read and study")]
    [TestCase("2024-03-08 08:00:00", "Have breakfast")]
    [TestCase("2024-03-08 08:30:00", "Have breakfast")]
    [TestCase("2024-03-08 09:15:00", "Coding time")]
    [TestCase("2024-03-08 09:45:00", "Watch Udemy course")]
    [TestCase("2024-03-08 04:30:00", "No activity")]
    [TestCase("2024-03-08 12:30:00", "No activity")]
    public void WhatShouldIDoNow_GivenTime_ReturnsExpectedActivity(string time, string expectedActivity)
    {
        // arrange
        Mock<IClock> clockMock = new Mock<IClock>();
        clockMock.Setup(x => x.Now()).Returns(DateTime.Parse(time));
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