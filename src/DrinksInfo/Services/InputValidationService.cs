using DrinksInfo.Contracts;

namespace DrinksInfo.Services;

public class InputValidationService
{
    public static bool IsValidCategory(string input, List<Category> categories)
    {
        bool isValid = false;

        if (categories.Any(x => x.Name == input))
        {
            isValid = true;
        }

        return isValid;
    }

    public static bool IsValidDrink(string input, List<Drink> drinks)
    {
        bool isValid = false;

        if (drinks.Any(x => x.Name ==input))
        {
            isValid = true;
        }

        return isValid;
    }
}
