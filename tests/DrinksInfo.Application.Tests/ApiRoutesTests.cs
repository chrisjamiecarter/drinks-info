using DrinksInfo.Application.Options;
using Shouldly;

namespace DrinksInfo.Application.Tests;

public class ApiRoutesTests
{
    [Fact]
    public void GetDrink_ShouldReturnEncodedUrl_WithCorrectId()
    {
        // Arrange.
        var options = Microsoft.Extensions.Options.Options.Create(new DrinkApiClientOptions
        {
            Root = "https://example.com/api",
            Version = "v1",
            Key = "abc123"
        });

        var routes = new ApiRoutes(options);

        // Act.
        var result = routes.GetDrink("Dr@nk#42");

        // Assert.
        result.ShouldBe("https://example.com/api/v1/abc123/lookup.php?i=Dr%40nk%2342");
    }

    [Fact]
    public void GetCategories_ShouldReturnStaticRoute_WithVersionAndKey()
    {
        // Arrange.
        var options = Microsoft.Extensions.Options.Options.Create(new DrinkApiClientOptions
        {
            Root = "https://api.example.com",
            Version = "v1",
            Key = "xyz987"
        });

        var routes = new ApiRoutes(options);

        // Act.
        var result = routes.GetCategories;

        // Assert.
        result.ShouldBe("https://api.example.com/v1/xyz987/list.php?c=list");
    }
}
