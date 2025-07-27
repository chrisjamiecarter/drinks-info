using ConsoleTableExt;
using DrinksInfo.Application.Models;
using Spectre.Console;
using System.Reflection;

namespace DrinksInfo.ConsoleApp.Engines;

/// <summary>
/// Engine for Spectre.Table generation.
/// </summary>
internal class TableEngine
{
    /// <summary>
    /// Generates the drink table.
    /// NOTE: Transposes the table and removes any null values.
    /// </summary>
    /// <param name="drink">The drink object to generate the properties into a table.</param>
    /// <returns>The generated spectre table object.</returns>
    internal static Table GetDrinkTable(Drink? drink)
    {
        Table table = new Table();

        if (drink is null)
        {
            table.AddColumn("Error");
            table.HideHeaders();
            table.AddRow("No drink could be retrieved.");
        }
        else
        {
            // Use reflection to get a list of non-null property values.
            var tableData = new List<KeyValuePair<string, string>>();
            foreach (PropertyInfo property in drink.GetType().GetProperties())
            {
                string? value = property.GetValue(drink)?.ToString();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    tableData.Add(new(property.Name, value));
                }
            }

            // Add columns although these will be hidden from the view.
            table.AddColumn("Key");
            table.AddColumn("Value");

            // Add each key value pair to a row.
            foreach (var kvp in tableData)
            {
                table.AddRow(kvp.Key, kvp.Value);
            }
        }

        // Hide header as table is transposed into KVPs.
        table.HideHeaders();

        // Expand the table to take up the full width of the console.
        table.Expand();

        return table;
    }
}
