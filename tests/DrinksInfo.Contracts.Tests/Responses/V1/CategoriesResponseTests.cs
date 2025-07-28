using DrinksInfo.Contracts.Responses.V1;
using Newtonsoft.Json;
using Shouldly;

namespace DrinksInfo.Contracts.Tests.Responses.V1;

public class CategoriesResponseTests
{
    [Fact]
    public void Deserialization_ShouldMapDrinksToValues()
    {
        // Arrange.
        var json = """
        {
            "drinks": [
                { "strCategory": "Sodas" },
                { "strCategory": "Juices" }
            ]
        }
        """;

        // Act.
        var result = JsonConvert.DeserializeObject<CategoriesResponse>(json);

        // Assert.
        result.ShouldNotBeNull();
        result.Values.ShouldNotBeNull();
        result.Values.Length.ShouldBe(2);
        result.Values.First().Name.ShouldBe("Sodas");
        result.Values.Last().Name.ShouldBe("Juices");
    }

    [Fact]
    public void Deserialization_ShouldHandleMissingDrinksKey()
    {
        // Arrange.
        var json = """{ }""";

        // Act.
        var result = JsonConvert.DeserializeObject<CategoriesResponse>(json);

        // Assert.
        result.ShouldNotBeNull();
        result.Values.ShouldBeNull();
    }
}