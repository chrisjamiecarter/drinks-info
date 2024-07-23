using System.Data;
using ConsoleTableExt;
using DrinksInfo.Contracts;
using Newtonsoft.Json;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Engines;

internal class TableVisualisationEngine
{
    internal static void ShowCategories(List<Category> categories)
    {
        Table table = new Table
        {
            Title = new("Categories")
        };
        table.AddColumn("Category");
        categories.ForEach(x => table.AddRow(x.Name!));

        ShowTable(table);
    }

    internal static void ShowDrinks(List<Drink> drinks)
    {
        Table table = new Table
        {
            Title = new("Drinks")
        };
        table.AddColumn("ID");
        table.AddColumn("Name");
        drinks.ForEach(x => table.AddRow(x.Id!, x.Name!));

        ShowTable(table);
    }

    internal static void ShowDrinkDetail(DrinkDetail drinkDetail)
    {
        Table table = new Table
        {
            Title = new("Drink Detail")
        };

        //  When the users visualise the drink detail, there shouldn't be any properties with empty values

        table.AddColumn("Key");
        table.AddColumn("Value");

        AddKvpRowToTable(table, "Id", drinkDetail.Id);
        AddKvpRowToTable(table, "Name", drinkDetail.Name);
        AddKvpRowToTable(table, "Drink Alternate", drinkDetail.strDrinkAlternate);
        AddKvpRowToTable(table, "strTags", drinkDetail.strTags);
        AddKvpRowToTable(table, "strVideo", drinkDetail.strVideo);
        AddKvpRowToTable(table, "strCategory", drinkDetail.strCategory);
        AddKvpRowToTable(table, "strIBA", drinkDetail.strIBA);
        AddKvpRowToTable(table, "strAlcoholic", drinkDetail.strAlcoholic);
        AddKvpRowToTable(table, "strGlass", drinkDetail.strGlass);
        AddKvpRowToTable(table, "strInstructions", drinkDetail.strInstructions);
        AddKvpRowToTable(table, "strDrinkThumb", drinkDetail.strDrinkThumb);
        AddKvpRowToTable(table, "strIngredient1", drinkDetail.strIngredient1);
        AddKvpRowToTable(table, "strIngredient2", drinkDetail.strIngredient2);
        AddKvpRowToTable(table, "strIngredient3", drinkDetail.strIngredient3);
        AddKvpRowToTable(table, "strIngredient4", drinkDetail.strIngredient4);
        AddKvpRowToTable(table, "strIngredient5", drinkDetail.strIngredient5);
        AddKvpRowToTable(table, "strIngredient6", drinkDetail.strIngredient6);
        AddKvpRowToTable(table, "strIngredient7", drinkDetail.strIngredient7);
        AddKvpRowToTable(table, "strIngredient8", drinkDetail.strIngredient8);
        AddKvpRowToTable(table, "strIngredient9", drinkDetail.strIngredient9);
        AddKvpRowToTable(table, "strIngredient10", drinkDetail.strIngredient10);
        AddKvpRowToTable(table, "strIngredient11", drinkDetail.strIngredient11);
        AddKvpRowToTable(table, "strIngredient12", drinkDetail.strIngredient12);
        AddKvpRowToTable(table, "strIngredient13", drinkDetail.strIngredient13);
        AddKvpRowToTable(table, "strIngredient14", drinkDetail.strIngredient14);
        AddKvpRowToTable(table, "strIngredient15", drinkDetail.strIngredient15);
        AddKvpRowToTable(table, "strMeasure1", drinkDetail.strMeasure1);
        AddKvpRowToTable(table, "strMeasure2", drinkDetail.strMeasure2);
        AddKvpRowToTable(table, "strMeasure3", drinkDetail.strMeasure3);
        AddKvpRowToTable(table, "strMeasure4", drinkDetail.strMeasure4);
        AddKvpRowToTable(table, "strMeasure5", drinkDetail.strMeasure5);
        AddKvpRowToTable(table, "strMeasure6", drinkDetail.strMeasure6);
        AddKvpRowToTable(table, "strMeasure7", drinkDetail.strMeasure7);
        AddKvpRowToTable(table, "strMeasure8", drinkDetail.strMeasure8);
        AddKvpRowToTable(table, "strMeasure9", drinkDetail.strMeasure9);
        AddKvpRowToTable(table, "strMeasure10", drinkDetail.strMeasure10);
        AddKvpRowToTable(table, "strMeasure11", drinkDetail.strMeasure11);
        AddKvpRowToTable(table, "strMeasure12", drinkDetail.strMeasure12);
        AddKvpRowToTable(table, "strMeasure13", drinkDetail.strMeasure13);
        AddKvpRowToTable(table, "strMeasure14", drinkDetail.strMeasure14);
        AddKvpRowToTable(table, "strMeasure15", drinkDetail.strMeasure15);
        AddKvpRowToTable(table, "strImageSource", drinkDetail.strImageSource);
        AddKvpRowToTable(table, "strImageAttribution", drinkDetail.strImageAttribution);
        AddKvpRowToTable(table, "strCreativeCommonsConfirmed", drinkDetail.strCreativeCommonsConfirmed);
        AddKvpRowToTable(table, "dateModified", drinkDetail.dateModified);

        ShowTable(table);
    }

    private static void AddKvpRowToTable(Table table, string key, string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
        {
            table.AddRow(key, value);
        }
    }

    private static void ShowTable(Table table)
    {
        AnsiConsole.Clear();

        AnsiConsole.Write(table);
    }
}
