namespace MenuMaster
{
    public class Menu : IMenu
    {
        private readonly List<Page> _pages;
        private readonly List<Dish> _dishCollection;
        private readonly int        _countDishesOnPage;
        /// <summary>
        /// Конструктор класса Menu
        /// </summary>
        /// <param name="dishCollection">Список из коллекции элементов string с названиями блюд</param>
        /// <param name="countDishesOnPage">Количество блюд на одной странице</param>
        public Menu(List<string> dishCollection, int countDishesOnPage)
        {
            if (dishCollection == null)                        throw new ArgumentNullException("dishCollection");
            if (dishCollection.Count < 1)                      throw new ArgumentException("Переданный список пуст");
            if (dishCollection.Exists(x => x == String.Empty)) throw new ArgumentException("В переданном списке существует пустой элемент");
            if (countDishesOnPage < 1)                         throw new ArgumentException("Количество элементов на странице должно быть больше 1");

            _dishCollection    = dishCollection.Select(x => new Dish() { Name = x }).ToList();
            _countDishesOnPage = countDishesOnPage;

            _pages = FillPages();
        }
        /// <summary>
        /// Конструктор класса Menu
        /// </summary>
        /// <param name="dishCollection">Список из коллекции элементов Dish</param>
        /// <param name="countDishesOnPage">Количество блюд на одной странице</param>
        public Menu(List<Dish> dishCollection, int countDishesOnPage)
        {
            if (dishCollection == null)                             throw new ArgumentNullException("dishCollection");
            if (dishCollection.Count < 1)                           throw new ArgumentException("Переданный список пуст");
            if (dishCollection.Exists(x => x.Name == String.Empty)) throw new ArgumentException("В переданном списке существует пустой элемент");
            if (countDishesOnPage < 1)                              throw new ArgumentException("Количество элементов на странице должно быть больше 1");

            _dishCollection    = dishCollection;
            _countDishesOnPage = countDishesOnPage;

            _pages = FillPages();
        }
        /// <summary>
        /// Получить количество блюд
        /// </summary>
        /// <returns>Целое число, общее количество блюд</returns>
        public int GetCountDishes() => _dishCollection.Count;
        /// <summary>
        /// Получить количество страниц
        /// </summary>
        /// <returns>Целое число, количество созданных страниц под блюда</returns>
        public int GetCountPages() => (int)Math.Ceiling((double)GetCountDishes() / _countDishesOnPage);
        /// <summary>
        /// Получить количество блюд на странице
        /// </summary>
        /// <param name="page">Порядковый номер страницы, начиная с 1</param>
        /// <returns>Целое число, количество блюд на странице int page</returns>
        /// <exception cref="Exception"></exception>
        public int GetCountDishesOnPage(int page) => (page <= GetCountPages() && page > 0) ? _pages[page - 1].CountDishes 
            : throw new ArgumentException($"Страницы {page} не существует");
        /// <summary>
        /// Получить блюда на странице
        /// </summary>
        /// <param name="page">Порядковый номер страницы, начиная с 1</param>
        /// <returns>Список string названий блюд</returns>
        /// <exception cref="Exception"></exception>
        public List<string> GetDishesOnPage(int page) => (page <= GetCountPages() && page > 0) ? _pages[page - 1].Dishes.Select(x => x.ToString()).ToList() 
            : throw new ArgumentException($"Страницы {page} не существует");
        /// <summary>
        /// Получить первое блюдо на каждой странице
        /// </summary>
        /// <returns>Список string названий первых блюд на странице</returns>
        public List<string> GetFirstDishOnEveryPage() => _pages.Select(x => x.First.ToString()).ToList();
        /// <summary>
        /// Получить первое блюдо страницы
        /// </summary>
        /// <param name="page">Порядковый номер страницы, начиная с 1</param>
        /// <returns>Возвращает string имя страницы</returns>
        /// <exception cref="Exception"></exception>
        public string GetFirstDish(int page) => (page <= GetCountPages() && page > 0) ? _pages[page - 1].First.ToString() 
            : throw new ArgumentException($"Страницы {page} не существует");

        private List<Page> FillPages()
        {
            List<Page> result = new List<Page>();

            for (int i = 0; i < GetCountDishes(); i += _countDishesOnPage)
            {
                List<Dish> dishesForPage = new List<Dish>();

                for (int j = 0; j < _countDishesOnPage; j++)
                {
                    if ((i + j) >= _dishCollection.Count) continue;

                    dishesForPage.Add(_dishCollection[i + j]);
                }

                result.Add(new Page() { Dishes = dishesForPage });
            }

            return result;
        }
    }
}
