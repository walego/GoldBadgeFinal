using BadgeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BadgeTests
{
    [TestClass]
    public class TestBadge
    {
        private BadgeRepo _badgeRepo;

        [TestInitialize]
        public void Arrange()
        {
            _badgeRepo = new BadgeRepo();
            List<string> list = new List<string> { "A7", "A8" };
            _badgeRepo.BadgeDictionary.Add(12345, list);
        }
        [TestMethod]
        public void CreateNewBadge_ShouldGetCorrectBool()
        {
            bool createResult = _badgeRepo.CreateNewBadge(22345);
            Assert.IsTrue(createResult);
        }
        [TestMethod]
        public void GetBadgeList_ShouldReturnCorrectDictionary()
        {
            Dictionary<int, List<string>> dictionary = _badgeRepo.GetBadgeList();
            bool dictionaryContent = dictionary.ContainsKey(12345);
            Assert.IsTrue(dictionaryContent);
        }
        public void AddDoor_ShouldReturnCorrectBool()
        {
            bool addDoorResult = _badgeRepo.AddDoor(12345, "B2");
            Assert.IsTrue(addDoorResult);
        }
        public void RemoveDoor_ShouldReturnCorrectBool()
        {
            bool removeDoorResult = _badgeRepo.RemoveDoor(12345, "A7");
            Assert.IsTrue(removeDoorResult);
        }
        public void DeleteAllDoors_ShouldReturnCorrectBool()
        {
            bool deleteAllDoorsResult = _badgeRepo.DeleteAllDoors(12345);
            Assert.IsTrue(deleteAllDoorsResult);
        }
        public void DeleteBadge_ShouldGetCorrectBool()
        {
            bool deleteBadgeResult = _badgeRepo.DeleteBadge(12345);
            Assert.IsTrue(deleteBadgeResult);
        }
    }
}
