using DrinksInfo.ConsoleApp.Models;
using Shouldly;

namespace DrinksInfo.ConsoleApp.Tests.Models;

public class UserChoiceTests
{
    [Fact]
    public void Constructor_ShouldSetPropertiesCorrectly()
    {
        // Arrange.
        int id = 42;
        string name = "Select Drink";

        // Act.
        var choice = new UserChoice(id, name);

        // Assert.
        choice.Id.ShouldBe(id);
        choice.Name.ShouldBe(name);
    }
}