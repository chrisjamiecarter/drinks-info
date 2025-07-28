using DrinksInfo.Contracts.Responses.V1;
using Newtonsoft.Json;
using Shouldly;

namespace DrinksInfo.Contracts.Tests.Responses.V1;

public class CategoryResponseTests
{
    [Fact]
    public void Deserialization_ShouldMapCategoryToName()
    {
        // Arrange.
        var json = """
        {
            "strCategory": "Sodas"
        }
        """;

        // Act.
        var result = JsonConvert.DeserializeObject<CategoryResponse>(json);

        // Assert.
        result.ShouldNotBeNull();
        result.Name.ShouldNotBeNull();
        result.Name.ShouldBe("Sodas");
    }

    [Fact]
    public void Deserialization_ShouldHandleMissingStrCategory()
    {
        // Arrange.
        var json = """{ }""";

        // Act.
        var result = JsonConvert.DeserializeObject<CategoryResponse>(json);

        // Assert.
        result.ShouldNotBeNull();
        result.Name.ShouldBeNull();
    }
}