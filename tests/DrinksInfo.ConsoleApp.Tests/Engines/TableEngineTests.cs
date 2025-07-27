using DrinksInfo.Application.Models;
using DrinksInfo.ConsoleApp.Engines;
using Shouldly;
using Spectre.Console;

namespace DrinksInfo.ConsoleApp.Tests.Engines;

public class TableEngineTests
{
    [Fact]
    public void GetDrinkTable_WhenDrinkIsNull_ShouldRenderErrorTable()
    {
        // Arrange.
        Drink? drink = null;

        // Act.
        Table result = TableEngine.GetDrinkTable(drink);

        // Assert.
        result.Columns.Count.ShouldBe(1);
        result.Rows.Count.ShouldBe(1);
        result.Expand.ShouldBe(true);
    }

    [Fact]
    public void GetDrinkTable_WhenDrinkHasValidProperties_ShouldRenderNonEmptyTable()
    {
        // Arrange
        var drink = new Drink
        {
            Name = "Test Drink",
            Category = "Test Category",
            Glass = "Test Glass",
            Instructions = "Test Instructions",
        };

        // Act
        Table result = TableEngine.GetDrinkTable(drink);

        // Assert
        result.Columns.Count.ShouldBe(2);
        result.Rows.Count.ShouldBe(4);
        result.Expand.ShouldBe(true);
    }
}
