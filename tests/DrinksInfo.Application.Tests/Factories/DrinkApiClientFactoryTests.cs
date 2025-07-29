using DrinksInfo.Application.Clients.V1;
using DrinksInfo.Application.Factories;
using DrinksInfo.Application.Options;
using Moq;
using RestSharp;
using Shouldly;

namespace DrinksInfo.Application.Tests.Factories;

public class DrinkApiClientFactoryTests
{
    [Fact]
    public void CreateClient_ShouldReturnV1Client_WhenVersionIsV1()
    {
        // Arrange.
        var options = Microsoft.Extensions.Options.Options.Create(new DrinkApiClientOptions
        {
            Version = "v1",
            Root = "https://example.com",
            Key = "1",
        });

        var mockRoutes = new ApiRoutes(options);
        var mockRestClient = new Mock<IRestClient>();

        var factory = new DrinkApiClientFactory(options, mockRoutes, mockRestClient.Object);

        // Act.
        var client = factory.CreateClient();

        // Assert.
        client.ShouldBeOfType<DrinkApiClient>();
    }

    [Fact]
    public void CreateClient_ShouldThrowNotSupportedException_WhenVersionIsUnsupported()
    {
        // Arrange.
        var options = Microsoft.Extensions.Options.Options.Create(new DrinkApiClientOptions
        {
            Version = "v2",
            Root = "https://example.com",
            Key = "1",
        });

        var mockRoutes = new ApiRoutes(options);
        var mockRestClient = new Mock<IRestClient>();

        var factory = new DrinkApiClientFactory(options, mockRoutes, mockRestClient.Object);

        // Act & Assert.
        var ex = Should.Throw<NotSupportedException>(() => factory.CreateClient());
        ex.Message.ShouldBe("Unsupported API version: v2");
    }
}
