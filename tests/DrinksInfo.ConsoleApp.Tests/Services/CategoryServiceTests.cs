using DrinksInfo.Application.Abstractions;
using DrinksInfo.Application.Models;
using DrinksInfo.ConsoleApp.Services;
using Moq;
using Shouldly;

namespace DrinksInfo.ConsoleApp.Tests.Services;

[Collection("Spectre Tests")]
public class CategoryServiceTests
{
    [Fact]
    public async Task GetCategoriesAsync_ShouldReturnCategoriesFromClient()
    {
        // Arrange
        var expected = new List<Category>
        {
            new() { Name = "Sodas" },
            new() { Name = "Juices" }
        };

        var mockClient = new Mock<IDrinkApiClient>();
        mockClient.Setup(c => c.GetCategoriesAsync())
                  .ReturnsAsync(expected);

        var mockProvider = new Mock<IDrinkApiClientProvider>();
        mockProvider.Setup(p => p.CreateClient())
                    .Returns(mockClient.Object);

        var service = new CategoryService(mockProvider.Object);

        // Act
        var result = await service.GetCategoriesAsync();

        // Assert
        result.ShouldBe(expected);
        mockClient.Verify(c => c.GetCategoriesAsync(), Times.Once);
    }
}
