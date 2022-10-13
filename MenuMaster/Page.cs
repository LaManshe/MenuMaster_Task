namespace MenuMaster
{
    internal class Page
    {
        public List<Dish> Dishes { get; set; }
        public int CountDishes
        {
            get
            {
                return Dishes.Count;
            }
        }
        
        public List<string> DishesStrings
        {
            get
            {
                return Dishes.Select(x => x.ToString()).ToList();
            }
        }

        public Dish First
        {
            get
            {
                return Dishes.FirstOrDefault() ?? throw new Exception("На странице нет блюд");
            }
        }
    }
}
