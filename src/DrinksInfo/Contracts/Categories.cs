using Newtonsoft.Json;

namespace DrinksInfo.Contracts;

public class Categories
{
    [JsonProperty("drinks")]
    public List<Category>? CategoriesList { get; set; }
}
