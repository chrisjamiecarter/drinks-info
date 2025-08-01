﻿using Newtonsoft.Json;

namespace DrinksInfo.Contracts.Responses.V1;

/// <summary>
/// A JSON reponse for a drink.
/// </summary>
public class DrinkResponse
{
    [JsonProperty("idDrink")]
    public string? Id { get; set; }

    [JsonProperty("strDrink")]
    public string? Name { get; set; }

    [JsonProperty("strDrinkAlternate")]
    public string? DrinkAlternate { get; set; }

    [JsonProperty("strTags")]
    public string? Tags { get; set; }

    [JsonProperty("strVideo")]
    public string? Video { get; set; }

    [JsonProperty("strCategory")]
    public string? Category { get; set; }

    [JsonProperty("strIBA")]
    public string? Iba { get; set; }

    [JsonProperty("strAlcoholic")]
    public string? Alcoholic { get; set; }

    [JsonProperty("strGlass")]
    public string? Glass { get; set; }

    [JsonProperty("strInstructions")]
    public string? Instructions { get; set; }

    [JsonProperty("strDrinkThumb")]
    public string? DrinkThumb { get; set; }

    [JsonProperty("strIngredient1")]
    public string? Ingredient1 { get; set; }

    [JsonProperty("strIngredient2")]
    public string? Ingredient2 { get; set; }

    [JsonProperty("strIngredient3")]
    public string? Ingredient3 { get; set; }

    [JsonProperty("strIngredient4")]
    public string? Ingredient4 { get; set; }

    [JsonProperty("strIngredient5")]
    public string? Ingredient5 { get; set; }

    [JsonProperty("strIngredient6")]
    public string? Ingredient6 { get; set; }

    [JsonProperty("strIngredient7")]
    public string? Ingredient7 { get; set; }

    [JsonProperty("strIngredient8")]
    public string? Ingredient8 { get; set; }

    [JsonProperty("strIngredient9")]
    public string? Ingredient9 { get; set; }

    [JsonProperty("strIngredient10")]
    public string? Ingredient10 { get; set; }

    [JsonProperty("strIngredient11")]
    public string? Ingredient11 { get; set; }

    [JsonProperty("strIngredient12")]
    public string? Ingredient12 { get; set; }

    [JsonProperty("strIngredient13")]
    public string? Ingredient13 { get; set; }

    [JsonProperty("strIngredient14")]
    public string? Ingredient14 { get; set; }

    [JsonProperty("strIngredient15")]
    public string? Ingredient15 { get; set; }

    [JsonProperty("strMeasure1")]
    public string? Measure1 { get; set; }

    [JsonProperty("strMeasure2")]
    public string? Measure2 { get; set; }

    [JsonProperty("strMeasure3")]
    public string? Measure3 { get; set; }

    [JsonProperty("strMeasure4")]
    public string? Measure4 { get; set; }

    [JsonProperty("strMeasure5")]
    public string? Measure5 { get; set; }

    [JsonProperty("strMeasure6")]
    public string? Measure6 { get; set; }

    [JsonProperty("strMeasure7")]
    public string? Measure7 { get; set; }

    [JsonProperty("strMeasure8")]
    public string? Measure8 { get; set; }

    [JsonProperty("strMeasure9")]
    public string? Measure9 { get; set; }

    [JsonProperty("strMeasure10")]
    public string? Measure10 { get; set; }

    [JsonProperty("strMeasure11")]
    public string? Measure11 { get; set; }

    [JsonProperty("strMeasure12")]
    public string? Measure12 { get; set; }

    [JsonProperty("strMeasure13")]
    public string? Measure13 { get; set; }

    [JsonProperty("strMeasure14")]
    public string? Measure14 { get; set; }

    [JsonProperty("strMeasure15")]
    public string? Measure15 { get; set; }

    [JsonProperty("strImageSource")]
    public string? ImageSource { get; set; }

    [JsonProperty("strImageAttribution")]
    public string? ImageAttribution { get; set; }

    [JsonProperty("strCreativeCommonsConfirmed")]
    public string? CreativeCommonsConfirmed { get; set; }

    [JsonProperty("dateModified")]
    public string? DateModified { get; set; }
}
