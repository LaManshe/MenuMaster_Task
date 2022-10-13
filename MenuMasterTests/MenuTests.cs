using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MenuMaster.Tests
{
    [TestClass()]
    public class MenuTests
    {
        private Menu _menu;
        private List<string> _items;
        private List<string> _items2;
        private List<string> _items3;
        private int _count;
        private int _count2;
        [TestInitialize]
        public void TestInitialize()
        {
            _items = new List<string>() { "Матча", "Латте", "Смузи", "Джин", "Эскимо" };
            _items2 = new List<string>() { "Матча", "Латте", "", "Джин", "Эскимо" };
            _items3 = new List<string>() { };
            _count = 2;
            _count2 = 0;
        }

        [TestMethod]
        public void ConstructorEmptyElementTest()
        {
            string result = "В переданном списке существует пустой элемент";
            string expected = String.Empty;
            try
            {
                _menu = new Menu(_items2, _count);
            }
            catch(Exception ex)
            {
                expected = ex.Message;
            }

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConstructorEmptyListTest()
        {
            string result = "Переданный список пуст";
            string expected = String.Empty;
            try
            {
                _menu = new Menu(_items3, _count);
            }
            catch (Exception ex)
            {
                expected = ex.Message;
            }

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void ConstructorZeroCountTest()
        {
            string result = "Количество элементов на странице должно быть больше 1";
            string expected = String.Empty;
            try
            {
                _menu = new Menu(_items, _count2);
            }
            catch (Exception ex)
            {
                expected = ex.Message;
            }

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetCountDishesTest()
        {
            #region Arrange
            _menu = new Menu(_items, _count);
            int expected = 5;
            #endregion
            #region Act
            var result = _menu.GetCountDishes();
            #endregion
            #region Assert
            Assert.AreEqual(expected, result);
            #endregion
        }

        [TestMethod]
        public void GetCountPagesTest()
        {
            #region Arrange
            _menu = new Menu(_items, _count);
            int expected = 3;
            #endregion
            #region Act
            var result = _menu.GetCountPages();
            #endregion
            #region Assert
            Assert.AreEqual(expected, result);
            #endregion
        }

        [TestMethod]
        public void GetCountDishesOnPageTest()
        {
            #region Arrange
            _menu = new Menu(_items, _count);

            int page1 = 1;
            int page3 = 3;
            int expected1 = 2;
            int expected3 = 1;
            #endregion
            #region Act
            int result1 = _menu.GetCountDishesOnPage(page1);
            int result3 = _menu.GetCountDishesOnPage(page3);
            #endregion
            #region Assert
            Assert.AreEqual(expected1, result1);
            Assert.AreEqual(expected3, result3);
            #endregion
        }

        [TestMethod]
        public void GetDishesOnPageTest()
        {
            #region Arrange
            _menu = new Menu(_items, _count);

            int page = 1;
            List<string> expected = new List<string>() { "Матча", "Латте" };
            #endregion
            #region Act
            List<string> result = _menu.GetDishesOnPage(page);
            #endregion
            #region Assert
            Assert.IsTrue(result.SequenceEqual(expected));
            #endregion
        }

        [TestMethod]
        public void GetFirstDishOnEveryPageTest()
        {
            #region Arrange
            _menu = new Menu(_items, _count);

            List<string> expected = new List<string>() { "Матча", "Смузи", "Эскимо" };
            #endregion
            #region Act
            List<string> result = _menu.GetFirstDishOnEveryPage();
            #endregion
            #region Assert
            Assert.IsTrue(result.SequenceEqual(expected));
            #endregion
        }

        [TestMethod]
        public void GetFirstDishTest()
        {
            #region Arrange
            _menu = new Menu(_items, _count);

            int page = 1;
            string expected = "Матча";
            #endregion
            #region Act
            string result = _menu.GetFirstDish(page);
            #endregion
            #region Assert
            Assert.AreEqual(expected, result);
            #endregion
        }
    }
}