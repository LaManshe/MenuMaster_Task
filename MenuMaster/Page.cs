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
        public Dish First
        {
            get
            {
                return Dishes.FirstOrDefault() ?? throw new Exception("На странице нет блюд");
            }
        }
    }
}
