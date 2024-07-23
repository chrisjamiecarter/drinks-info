using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DrinksInfo.Contracts;

public class Drink
{
    [JsonProperty("idDrink")]
    public string? Id { get; set; }

    [JsonProperty("strDrink")]
    public string? Name { get; set; }
    
}
