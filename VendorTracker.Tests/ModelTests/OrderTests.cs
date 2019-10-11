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
        [TestMethod]
        public void GetAll_ReturnsAllOrderInList_List()
        {
            List<Order> expectedList = new List<Order>{newOrder};
            List<Order> gotAll = Order.GetAll();
            CollectionAssert.AreEqual(gotAll,expectedList);
        }
        [TestMethod]
        public void ClearAll_ClearsAllOrdersInList_List()
        {
            List<Order> emptyList = new List<Order> {};
            Order.ClearAll();
            List<Order> gotAll = Order.GetAll();
            CollectionAssert.AreEqual(emptyList,gotAll);
        }
        [TestMethod]
        public void Find_AbleToFindElementById_Order()
        {
            int expectedID = 1;
            Order foundOrder = Order.Find(expectedID);
            Assert.AreEqual(newOrder,foundOrder);
        }
    }
}