using Newtonsoft.Json;

namespace DrinksInfo.Contracts;

public class DrinkDetails
{
    [JsonProperty("drinks")]
    public List<DrinkDetail>? DrinkDetailsList { get; set; }
}
