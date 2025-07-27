using DrinksInfo.ConsoleApp.Extensions;
using Shouldly;
using System.ComponentModel;

namespace DrinksInfo.ConsoleApp.Tests.Extensions;

public class EnumExtensionsTests
{
    private const string EnumDescription = "Value with description";

    private enum TestEnum
    {
        [Description(EnumDescription)]
        ValueWithDescription = 0,
        
        ValueWithoutDescription = 1,
    }

    [Fact]
    public void GetDescription_WhenEnumHasDescription_ShouldReturnDescription()
    {
        // Arrange.
        var value = TestEnum.ValueWithDescription;
     
        // Act.
        string result = value.GetDescription();
        
        // Assert.
        result.ShouldBe(EnumDescription);
    }

    [Fact]
    public void GetDescription_WhenEnumHasNoDescription_ShouldReturnEnumValue()
    {
        // Arrange.
        var value = TestEnum.ValueWithoutDescription;

        // Act.
        string result = value.GetDescription();

        // Assert.
        result.ShouldBe(value.ToString());
    }
}
