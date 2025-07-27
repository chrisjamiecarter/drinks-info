using DrinksInfo.Models;

namespace DrinksInfo.Clients;

/// <summary>
/// Defines the contract for a client that interacts with a drink API.
/// </summary>
internal interface IDrinkApiClient
{
    Task<IReadOnlyList<Category>> GetCategoriesAsync();
    Task<Drink?> GetDrinkByIdAsync(string id);
    Task<IReadOnlyList<Drink>> GetDrinksByCategoryNameAsync(string categoryName);
    Task<Drink?> GetRandomDrinkAsync();
}
