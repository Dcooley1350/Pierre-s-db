using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorTracker.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace VendorTracker.Tests
{
    [TestClass]
    public class OrderTest
    {
        int breads;
        int pastries;
        Order newOrder;

        [TestInitialize]
        public void Setup()
        {
            breads = 3;
            pastries = 5;
            newOrder = new Order(breads,pastries);
        }
        [TestCleanup]
        public void TearDown()
        {
            Order.ClearAll();
        }
        [TestMethod]
        public void Constructor_ConstructorBuildsInstance_Order()
        {
            Assert.AreEqual(newOrder.GetType(),typeof(Order));
        }
    }
}