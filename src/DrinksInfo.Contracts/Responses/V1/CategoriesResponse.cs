using Newtonsoft.Json;

namespace DrinksInfo.Contracts.Responses.V1;

/// <summary>
/// A JSON reponse for a collection of categories.
/// </summary>
public class CategoriesResponse
{
    [JsonProperty("drinks")]
    public CategoryResponse[]? Values { get; set; }
}
