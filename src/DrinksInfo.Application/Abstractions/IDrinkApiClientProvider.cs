namespace DrinksInfo.Application.Abstractions;

public interface IDrinkApiClientProvider
{
    IDrinkApiClient CreateClient();
}