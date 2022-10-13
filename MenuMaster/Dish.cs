namespace MenuMaster
{
    public class Dish
    {
        /// <summary>
        /// Имя блюда
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Переопределение ToString метода
        /// </summary>
        /// <returns>Имя блюда</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
