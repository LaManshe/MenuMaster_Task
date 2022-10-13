namespace MenuMaster
{
    public interface IMenu
    {
        int GetCountDishes();
        int GetCountDishesOnPage(int page);
        int GetCountPages();
        List<string> GetDishesOnPage(int page);
        List<string> GetFirstDishOnEveryPage();
    }
}