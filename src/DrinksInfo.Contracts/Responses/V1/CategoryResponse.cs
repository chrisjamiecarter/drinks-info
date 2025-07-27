using Newtonsoft.Json;

namespace DrinksInfo.Contracts.Responses.V1;

/// <summary>
/// A JSON reponse for a category.
/// </summary>
public class CategoryResponse
{
    [JsonProperty("strCategory")]
    public string? Name { get; set; }
}
