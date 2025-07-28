using DrinksInfo.Contracts.Responses.V1;
using Newtonsoft.Json;
using Shouldly;

namespace DrinksInfo.Contracts.Tests.Responses.V1;

public class DrinksResponseTests
{
    [Fact]
    public void Deserialization_ShouldMapDrinksToValues()
    {
        // Arrange.
        var json = """
        {
            "drinks": [
                { "idDrink": "123" },
                { "idDrink": "456" }
            ]
        }
        """;

        // Act.
        var result = JsonConvert.DeserializeObject<DrinksResponse>(json);

        // Assert.
        result.ShouldNotBeNull();
        result.Values.ShouldNotBeNull();
        result.Values.Length.ShouldBe(2);
        result.Values.First().Id.ShouldBe("123");
        result.Values.Last().Id.ShouldBe("456");
    }

    [Fact]
    public void Deserialization_ShouldHandleMissingDrinksKey()
    {
        // Arrange.
        var json = """{ }""";

        // Act.
        var result = JsonConvert.DeserializeObject<DrinksResponse>(json);

        // Assert.
        result.ShouldNotBeNull();
        result.Values.ShouldBeNull();
    }
}