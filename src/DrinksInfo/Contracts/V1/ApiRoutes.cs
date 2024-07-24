namespace DrinksInfo.Contracts.V1;

public static class ApiRoutes
{
    #region Constants

    private const string Root = "https://www.thecocktaildb.com/api/json";

    private const string Version = "v1";

    private const string Key = "1";

    private const string Base = @$"{Root}\{Version}\{Key}";

    #endregion
    #region Routes

    public static class Categories
    {
        public const string GetAll = $"{Base}/list.php?c=list";
    }

    public static class Drinks
    {
        public const string Get = $"{Base}/lookup.php?i={{drinkId}}";

        public const string GetByCategory = $"{Base}/filter.php?c={{category}}";

        public const string GetRandom = $"{Base}/random.php";
    }

    #endregion
}
