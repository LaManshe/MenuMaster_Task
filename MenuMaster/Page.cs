namespace MenuMaster
{
    internal class Page
    {
        /// <summary>
        /// Список блюд на странице
        /// </summary>
        public List<Dish> Dishes { get; set; }
        /// <summary>
        /// Количество блюд на странице
        /// </summary>
        public int CountDishes
        {
            get
            {
                return Dishes.Count;
            }
        }
        /// <summary>
        /// Первое блюдо на странице
        /// </summary>
        public Dish First
        {
            get
            {
                return Dishes.FirstOrDefault() ?? throw new Exception("На странице нет блюд");
            }
        }
    }
}
