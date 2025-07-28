using DrinksInfo.Contracts.Responses.V1;
using Newtonsoft.Json;
using Shouldly;

namespace DrinksInfo.Contracts.Tests.Responses.V1;

public class DrinkResponseTests
{
    [Fact]
    public void Deserialization_ShouldMapEssentialFields()
    {
        // Arrange.
        var json = """
        {
            "idDrink": "11007",
            "strDrink": "Margarita",
            "strCategory": "Cocktail",
            "strGlass": "Cocktail glass",
            "strIngredient1": "Tequila",
            "strMeasure1": "1 1/2 oz",
            "dateModified": "2015-08-18 14:42:59"
        }
        """;

        // Act.
        var result = JsonConvert.DeserializeObject<DrinkResponse>(json);

        // Assert.
        result.ShouldNotBeNull();
        result.Id.ShouldBe("11007");
        result.Name.ShouldBe("Margarita");
        result.Category.ShouldBe("Cocktail");
        result.Glass.ShouldBe("Cocktail glass");
        result.Ingredient1.ShouldBe("Tequila");
        result.Measure1.ShouldBe("1 1/2 oz");
        result.DateModified.ShouldBe("2015-08-18 14:42:59");
    }

    [Fact]
    public void Deserialization_ShouldHandleMissingOptionalFields()
    {
        // Arrange.
        var json = """
        {
            "idDrink": "11007",
            "strDrink": "Margarita",
            "strCategory": "Cocktail",
            "strGlass": "Cocktail glass",
            "strIngredient1": "Tequila",
            "strMeasure1": "1 1/2 oz",
            "dateModified": "2015-08-18 14:42:59"
        }
        """;

        // Act.
        var result = JsonConvert.DeserializeObject<DrinkResponse>(json);

        // Assert.
        result.ShouldNotBeNull();
        result.Id.ShouldBe("11007");
        result.Ingredient15.ShouldBeNull();
        result.Measure15.ShouldBeNull();
    }
}