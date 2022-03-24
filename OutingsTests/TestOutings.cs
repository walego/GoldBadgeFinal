using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutingsRepository;
using System;
using System.Collections.Generic;

namespace OutingsTests
{
    [TestClass]
    public class TestOutings
    {
        [TestMethod]
        public void CreateOuting_ShouldGetCorrectBool()
        {
            OutingRepo outingRepo = new OutingRepo();
            Outing outing = new Outing();
            bool wasAdded = outingRepo.AddNewOuting(outing);
            Assert.IsTrue(wasAdded);
        }
        private OutingRepo _outingRepo;
        private Outing _outingOne;
        private Outing _outingTwo;
        private Outing _outingThree;
        [TestInitialize]
        public void Arrange()
        {
            _outingRepo = new OutingRepo();
            DateTime date = new DateTime(2022, 3, 10);
            _outingOne = new Outing(4, date, 100m, Outing.EventType.Golf);
            _outingTwo = new Outing(5, date, 200m, Outing.EventType.Golf);
            _outingThree = new Outing(4, date, 100m, Outing.EventType.Bowling);
            _outingRepo.AddNewOuting(_outingOne);
            _outingRepo.AddNewOuting(_outingTwo);
            _outingRepo.AddNewOuting(_outingThree);
        }
        [TestMethod]
        public void GetAllOutings_ShouldGetCorrectList()
        {
            List<Outing> list = _outingRepo.GetAllOutings();
            bool containsOutings = list.Contains(_outingOne) && list.Contains(_outingTwo) && list.Contains(_outingThree);
            Assert.IsTrue(containsOutings);
        }
        [TestMethod]
        public void GetCostAll_ShouldReturnCorrectDecimal()
        {
            decimal totalCost = _outingRepo.GetTotalCostAll();
            Assert.AreEqual(totalCost, 400m);
        }
        [TestMethod]
        public void GetCostByType_ShouldReturnCorrectDecimal()
        {
            decimal totalCost = _outingRepo.GetTotalCostByType(Outing.EventType.Golf);
            Assert.AreEqual(totalCost, 300m);
        }
    }
}
