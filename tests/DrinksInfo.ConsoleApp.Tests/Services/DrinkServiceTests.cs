using DrinksInfo.Application.Abstractions;
using DrinksInfo.Application.Models;
using DrinksInfo.ConsoleApp.Services;
using Moq;
using Shouldly;

namespace DrinksInfo.ConsoleApp.Tests.Services;

[Collection("Spectre Tests")]
public class DrinkServiceTests
{
    [Fact]
    public async Task GetDrinkAsync_ShouldReturnDrinkFromClient_WhenIdIsValid()
    {
        // Arrange.
        var drinkId = "123";
        var expected = new Drink
        {
            Id = drinkId,
            Name = "Test Drink",
            Category = "Test Category",
            Glass = "Test Glass",
            Instructions = "Test Instructions"
        };

        var mockClient = new Mock<IDrinkApiClient>();
        mockClient.Setup(c => c.GetDrinkByIdAsync(drinkId))
                  .ReturnsAsync(expected);

        var mockProvider = new Mock<IDrinkApiClientProvider>();
        mockProvider.Setup(p => p.CreateClient())
                    .Returns(mockClient.Object);

        var service = new DrinkService(mockProvider.Object);

        // Act.
        var result = await service.GetDrinkAsync(drinkId);

        // Assert.
        result.ShouldBe(expected);
        mockClient.Verify(c => c.GetDrinkByIdAsync(drinkId), Times.Once);
    }

    [Fact]
    public async Task GetDrinkAsync_ShouldReturnNullFromClient_WhenIdIsInvalid()
    {
        // Arrange.
        var drinkId = "123";
        Drink? expected = null;

        var mockClient = new Mock<IDrinkApiClient>();
        mockClient.Setup(c => c.GetDrinkByIdAsync(drinkId))
                  .ReturnsAsync(expected);

        var mockProvider = new Mock<IDrinkApiClientProvider>();
        mockProvider.Setup(p => p.CreateClient())
                    .Returns(mockClient.Object);

        var service = new DrinkService(mockProvider.Object);

        // Act.
        var result = await service.GetDrinkAsync(drinkId);

        // Assert.
        result.ShouldBe(expected);
        mockClient.Verify(c => c.GetDrinkByIdAsync(drinkId), Times.Once);
    }

    [Fact]
    public async Task GetDrinksByCategoryAsync_ShouldReturnDrinksFromClient_WhenCategoryIsValid()
    {
        // Arrange.
        var categoryName = "Test Category";
        var expected = new List<Drink>
        {
            new() { Id = "1", Name = "Drink 1"},
            new() { Id = "2", Name = "Drink 2"},
        };

        var mockClient = new Mock<IDrinkApiClient>();
        mockClient.Setup(c => c.GetDrinksByCategoryNameAsync(categoryName))
                  .ReturnsAsync(expected);

        var mockProvider = new Mock<IDrinkApiClientProvider>();
        mockProvider.Setup(p => p.CreateClient())
                    .Returns(mockClient.Object);

        var service = new DrinkService(mockProvider.Object);

        // Act.
        var result = await service.GetDrinksByCategoryAsync(categoryName);

        // Assert.
        result.ShouldBe(expected);
        mockClient.Verify(c => c.GetDrinksByCategoryNameAsync(categoryName), Times.Once);
    }

    [Fact]
    public async Task GetDrinkAsync_ShouldReturnEmptyListFromClient_WhenCategoryIsInvalid()
    {
        // Arrange.
        var categoryName = "Test Category";
        var expected = new List<Drink>();

        var mockClient = new Mock<IDrinkApiClient>();
        mockClient.Setup(c => c.GetDrinksByCategoryNameAsync(categoryName))
                  .ReturnsAsync(expected);

        var mockProvider = new Mock<IDrinkApiClientProvider>();
        mockProvider.Setup(p => p.CreateClient())
                    .Returns(mockClient.Object);

        var service = new DrinkService(mockProvider.Object);

        // Act.
        var result = await service.GetDrinksByCategoryAsync(categoryName);

        // Assert.
        result.ShouldBe(expected);
        mockClient.Verify(c => c.GetDrinksByCategoryNameAsync(categoryName), Times.Once);
    }

    [Fact]
    public async Task GetRandomDrinkAsync_ShouldReturnDrinkFromClient()
    {
        // Arrange.
        var expected = new Drink
        {
            Id = "123",
            Name = "Test Drink",
            Category = "Test Category",
            Glass = "Test Glass",
            Instructions = "Test Instructions"
        };

        var mockClient = new Mock<IDrinkApiClient>();
        mockClient.Setup(c => c.GetRandomDrinkAsync())
                  .ReturnsAsync(expected);

        var mockProvider = new Mock<IDrinkApiClientProvider>();
        mockProvider.Setup(p => p.CreateClient())
                    .Returns(mockClient.Object);

        var service = new DrinkService(mockProvider.Object);

        // Act.
        var result = await service.GetRandomDrinkAsync();

        // Assert.
        result.ShouldBe(expected);
        mockClient.Verify(c => c.GetRandomDrinkAsync(), Times.Once);
    }
}
