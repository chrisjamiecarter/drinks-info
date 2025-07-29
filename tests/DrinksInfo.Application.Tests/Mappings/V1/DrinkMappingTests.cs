using DrinksInfo.Contracts.Responses.V1;
using DrinksInfo.Application.Mappings.V1;
using Shouldly;
using DrinksInfo.Application.Models;

namespace DrinksInfo.Application.Tests.Mappings.V1;

public class DrinkMappingTests
{
    [Fact]
    public void ToDrink_ShouldReturnDrink_WhenResponseIsValid()
    {
        // Arrange.
        string id = "12345";
        string name = "test";
        string category = "Cocktails";

        var expected = new Drink
        {
            Id = id,
            Name = name,
            Category = category,
            Instructions = string.Empty,
        };

        var response = new DrinkResponse
        {
            Id = id,
            Name = name,
            Category = category,
            Instructions = null,
        };

        // Act.
        var drink = response.ToDrink();

        // Assert.s
        drink.ShouldNotBeNull();
        drink.ShouldBeEquivalentTo(expected);
    }
}
