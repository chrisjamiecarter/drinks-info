namespace DrinksInfo.ConsoleApp.Models;

/// <summary>
/// Represents a choice which a user can select.
/// </summary>
internal class UserChoice
{
    public UserChoice(int id, string name)
    {
        Id = id;
        Name = name;
    }

    internal int Id { get; init; }
    internal string? Name { get; init; }
}

