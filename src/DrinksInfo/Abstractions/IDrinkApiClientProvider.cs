namespace DrinksInfo.Abstractions;

public interface IDrinkApiClientProvider
{
    IDrinkApiClient CreateClient();
}