using DrinksInfo.Application.Abstractions;
using DrinksInfo.Application.Options;
using Microsoft.Extensions.Options;
using RestSharp;

namespace DrinksInfo.Application.Factories;

public class DrinkApiClientFactory : IDrinkApiClientProvider
{
    private readonly DrinkApiClientOptions _options;
    private readonly ApiRoutes _routes;
    private readonly IRestClient _restClient;

    public DrinkApiClientFactory(IOptions<DrinkApiClientOptions> options, ApiRoutes routes, IRestClient restClient)
    {
        _options = options.Value;
        _routes = routes;
        _restClient = restClient;
    }

    public IDrinkApiClient CreateClient()
    {
        return _options.Version switch
        {
            "v1" => new Clients.V1.DrinkApiClient(_routes, _restClient),
            _ => throw new NotSupportedException($"Unsupported API version: {_options.Version}")
        };
    }
}
