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
    public void WhatShouldIDoNow_GivenTime_ReturnsExpectedActivity(string time, string expectedActivity)
    {
        // arrange
        Mock<IClock> clockMock = new Mock<IClock>();
        clockMock.Setup(x => x.Now()).Returns(DateTime.Parse(time));
        IMorningRoutine morningRoutine = new MorningRoutine(clockMock.Object);

        // act
        var activityToDo = morningRoutine.WhatShouldIDoNow();

        // assert
        activityToDo.Should().Be(expectedActivity);
    }
}