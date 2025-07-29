using DrinksInfo.Contracts.Responses.V1;
using DrinksInfo.Application.Mappings.V1;
using Shouldly;
using DrinksInfo.Application.Models;

namespace DrinksInfo.Application.Tests.Mappings.V1;

public class CategoryMappingTests
{
    [Fact]
    public void ToCategory_ShouldReturnCategory_WhenResponseIsValid()
    {
        // Arrange.
        string categoryName = "Cocktail";

        var expected = new Category
        {
            Name = categoryName,
        };

        var response = new CategoryResponse
        {
            Name = categoryName,
        };

        // Act.
        var category = response.ToCategory();
        
        // Assert.s
        category.ShouldNotBeNull();
        category.ShouldBeEquivalentTo(expected);
    }

    [Fact]
    public void ToCategory_ShouldReturnCategory_WhenResponseNameIsNull()
    {
        // Arrange.
        var expected = new Category
        {
            Name = string.Empty,
        };

        var response = new CategoryResponse();

        // Act.
        var category = response.ToCategory();

        // Assert.
        category.ShouldNotBeNull();
        category.ShouldBeEquivalentTo(expected);
    }
}
