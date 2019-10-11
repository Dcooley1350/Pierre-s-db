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
            string name;
            string description;
            int price;
            string date;
        Order newOrder;

        [TestInitialize]
        public void Setup()
        {
            name = "BigMuffuginOrder";
            description ="SeeName";
            price = 30;
            date = "10/10/2019";
            newOrder = new Order(name,description,price,date);
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