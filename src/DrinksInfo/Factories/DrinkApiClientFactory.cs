using DrinksInfo.Abstractions;
using DrinksInfo.Options;
using Microsoft.Extensions.Options;

namespace DrinksInfo.Factories;

public class DrinkApiClientFactory : IDrinkApiClientProvider
{
    private readonly DrinkApiClientOptions _options;
    private readonly ApiRoutes _routes;

    public DrinkApiClientFactory(IOptions<DrinkApiClientOptions> options, ApiRoutes routes)
    {
        _options = options.Value;
        _routes = routes;
    }

    public IDrinkApiClient CreateClient()
    {
        return _options.Version switch
        {
            "v1" => new Clients.V1.DrinkApiClient(_routes),
            _ => throw new NotSupportedException($"Unsupported API version: {_options.Version}")
        };
    }
}
