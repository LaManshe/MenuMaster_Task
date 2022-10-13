using MenuMaster;

internal class Program
{
    private static void Main(string[] args)
    {
        Menu menu = new Menu(new List<string> { "Суп", "Горячее", "Напиток" }, 1);

        Console.WriteLine($"Общее количество блюд: {menu.GetCountDishes()}");
        Console.WriteLine($"Количество страниц: {menu.GetCountPages()}");
        Console.WriteLine($"Количество блюд на 2 странице: {menu.GetCountDishesOnPage(1)}");
        Console.WriteLine($"Блюда 1 странице:");
        foreach (var dish in menu.GetDishesOnPage(1))
        {
            Console.WriteLine(dish.ToString());
        }
        Console.WriteLine($"Список первых блюд каждой страницы:");
        foreach (var firstDish in menu.GetFirstDishOnEveryPage())
        {
            Console.WriteLine(firstDish.ToString());
        }
    }
}