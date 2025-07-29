using DrinksInfo.Application.Clients.V1;
using DrinksInfo.Application.Models;
using DrinksInfo.Application.Options;
using Moq;
using RestSharp;
using Shouldly;
using System.Net;

namespace DrinksInfo.Application.Tests.Clients.V1;

public class DrinkApiClientTests
{
    [Fact]
    public async Task GetCategoriesAsync_ShouldReturnMappedCategories_WhenApiReturnsValidResponse()
    {
        // Arrange.
        var expected = new Category[]
        {
            new() { Name = "Cocktails" },
            new() { Name = "Sodas" }
        };

        var json = """
        {
            "drinks": [
                { "strCategory": "Cocktails" },
                { "strCategory": "Sodas" }
            ]
        }
        """;

        var mockRestClient = new Mock<IRestClient>();
        mockRestClient
            .Setup(x => x.ExecuteAsync(It.IsAny<RestRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new RestResponse
            {
                Content = json,
                StatusCode = HttpStatusCode.OK,
                IsSuccessStatusCode = true
            });

        var options = Microsoft.Extensions.Options.Options.Create(new DrinkApiClientOptions
        {
            Root = "https://example.com/api",
            Version = "v1",
            Key = "1"
        });

        var routes = new ApiRoutes(options);
        var client = new DrinkApiClient(routes, mockRestClient.Object);

        // Act.
        var result = await client.GetCategoriesAsync();

        // Assert.
        result.ShouldNotBeNull();
        result.Count.ShouldBe(expected.Length);
        result.ToArray().ShouldBeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetDrinkByIdAsync_ShouldReturnMappedDrink_WhenApiReturnsValidResponse()
    {
        // Arrange.
        string drinkId = "11000";

        var expected = new Drink
        {
            Id = drinkId,
            Name = "Mojito",
            Category = "Cocktail",
            Instructions = "Muddle mint leaves with sugar and lime juice. Add a splash of soda water and fill the glass with cracked ice. Pour the rum and top with soda water. Garnish and serve with straw.",
        };

        var json = """
        {
            "drinks": [{ 
                "idDrink": "11000",
                "strDrink": "Mojito",
                "strCategory": "Cocktail",
                "strInstructions": "Muddle mint leaves with sugar and lime juice. Add a splash of soda water and fill the glass with cracked ice. Pour the rum and top with soda water. Garnish and serve with straw.",
            }]
        }
        """;

        var mockRestClient = new Mock<IRestClient>();
        mockRestClient
            .Setup(x => x.ExecuteAsync(It.IsAny<RestRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new RestResponse
            {
                Content = json,
                StatusCode = HttpStatusCode.OK,
                IsSuccessStatusCode = true
            });

        var options = Microsoft.Extensions.Options.Options.Create(new DrinkApiClientOptions
        {
            Root = "https://example.com/api",
            Version = "v1",
            Key = "1"
        });

        var routes = new ApiRoutes(options);
        var client = new DrinkApiClient(routes, mockRestClient.Object);

        // Act.
        var result = await client.GetDrinkByIdAsync(drinkId);

        // Assert.
        result.ShouldNotBeNull();
        result.ShouldBeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetDrinksByCategoryNameAsync_ShouldReturnMappedDrink_WhenApiReturnsValidResponse()
    {
        // Arrange.
        string categoryName = "Cocktail";

        var expected = new Drink[]
        {
            new ()
            {
                Id = "11000",
                Name = "Mojito",
                Category = categoryName,
                Instructions = "Muddle mint leaves with sugar and lime juice. Add a splash of soda water and fill the glass with cracked ice. Pour the rum and top with soda water. Garnish and serve with straw.",
            },
            new ()
            {
                Id = "11728",
                Name = "Mojito",
                Category = categoryName,
                Instructions = "Straight: Pour all ingredients into mixing glass with ice cubes. Stir well. Strain in chilled martini cocktail glass. Squeeze oil from lemon peel onto the drink, or garnish with olive.",
            }
        };

        var json = """
        {
            "drinks": [{ 
                "idDrink": "11000",
                "strDrink": "Mojito",
                "strCategory": "Cocktail",
                "strInstructions": "Muddle mint leaves with sugar and lime juice. Add a splash of soda water and fill the glass with cracked ice. Pour the rum and top with soda water. Garnish and serve with straw.",
            },{
                "idDrink": "11728",
                "strDrink": "Mojito",
                "strCategory": "Cocktail",
                "strInstructions": "Straight: Pour all ingredients into mixing glass with ice cubes. Stir well. Strain in chilled martini cocktail glass. Squeeze oil from lemon peel onto the drink, or garnish with olive.",
            }]
        }
        """;

        var mockRestClient = new Mock<IRestClient>();
        mockRestClient
            .Setup(x => x.ExecuteAsync(It.IsAny<RestRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new RestResponse
            {
                Content = json,
                StatusCode = HttpStatusCode.OK,
                IsSuccessStatusCode = true
            });

        var options = Microsoft.Extensions.Options.Options.Create(new DrinkApiClientOptions
        {
            Root = "https://example.com/api",
            Version = "v1",
            Key = "1"
        });

        var routes = new ApiRoutes(options);
        var client = new DrinkApiClient(routes, mockRestClient.Object);

        // Act.
        var result = await client.GetDrinksByCategoryNameAsync(categoryName);

        // Assert.
        result.ShouldNotBeNull();
        result.Count.ShouldBe(expected.Length);
        result.ToArray().ShouldBeEquivalentTo(expected);
    }

    [Fact]
    public async Task GetRandomDrinkAsync_ShouldReturnMappedDrink_WhenApiReturnsValidResponse()
    {
        // Arrange.
        var expected = new Drink
        {
            Id = "11000",
            Name = "Mojito",
            Category = "Cocktail",
            Instructions = "Muddle mint leaves with sugar and lime juice. Add a splash of soda water and fill the glass with cracked ice. Pour the rum and top with soda water. Garnish and serve with straw.",
        };

        var json = """
        {
            "drinks": [{ 
                "idDrink": "11000",
                "strDrink": "Mojito",
                "strCategory": "Cocktail",
                "strInstructions": "Muddle mint leaves with sugar and lime juice. Add a splash of soda water and fill the glass with cracked ice. Pour the rum and top with soda water. Garnish and serve with straw.",
            }]
        }
        """;

        var mockRestClient = new Mock<IRestClient>();
        mockRestClient
            .Setup(x => x.ExecuteAsync(It.IsAny<RestRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new RestResponse
            {
                Content = json,
                StatusCode = HttpStatusCode.OK,
                IsSuccessStatusCode = true
            });

        var options = Microsoft.Extensions.Options.Options.Create(new DrinkApiClientOptions
        {
            Root = "https://example.com/api",
            Version = "v1",
            Key = "1"
        });

        var routes = new ApiRoutes(options);
        var client = new DrinkApiClient(routes, mockRestClient.Object);

        // Act.
        var result = await client.GetRandomDrinkAsync();

        // Assert.
        result.ShouldNotBeNull();
        result.ShouldBeEquivalentTo(expected);
    }
}