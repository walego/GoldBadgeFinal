using CafeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CafeTests
{
    [TestClass]
    public class TestCafe
    {
        [TestMethod]
        public void AddMenuItem_ShouldReturnCorrectBool()
        {
            CafeRepo cafeRepo = new CafeRepo();
            MenuItem item = new MenuItem();
            bool addResult = cafeRepo.AddMenuItem(item);
            Assert.IsTrue(addResult);
        }
        private CafeRepo _cafeRepo;
        private MenuItem _item;
        [TestInitialize]
        public void Arrange()
        {
            _cafeRepo = new CafeRepo();
            _item = new MenuItem(1, "cereal", "a bowl of cereal", 1.85m);
            _cafeRepo.AddMenuItem(_item);
        }
        [TestMethod]
        public void AddIngredient_ShouldGetCorrectBool()
        {
            bool addIngredResult = _cafeRepo.AddIngredientToItem(_item, "cereal");
            Assert.IsTrue(addIngredResult);
        }
        [TestMethod]
        public void GetMenuItemByNumber_ShouldGetCorrectItem()
        {
            MenuItem item = _cafeRepo.GetMenuItemByNumber(1);
            Assert.AreEqual(item, _item);
        }
        [TestMethod]
        public void GetAllMenuItems_ShouldGetCorrectList()
        {
            List<MenuItem> list = _cafeRepo.GetAllMenuItems();
            bool menuItemEqual = list.Contains(_item);
            Assert.IsTrue(menuItemEqual);
        }
        [TestMethod]
        public void RemoveMenuItem_ShouldGetCorrectBool()
        {
            bool removeResult = _cafeRepo.RemoveMenuItem(_item);
            Assert.IsTrue(removeResult);
        }
    }
}
